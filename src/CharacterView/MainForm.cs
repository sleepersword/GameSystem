using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystem;
using System.IO;

namespace CharacterView
{
    public partial class MainForm : Form
    {
        public Character ActiveChar { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            
        }

        #region Private Methods

        private void SetCharacter(Character character)
        {
            ActiveChar = character;
            ResetPanelMain();

            txtID.Text = ActiveChar.ID.ToString();
            txtName.Text = ActiveChar.Name;
            
            txtName.Enabled = false;
            cmdCreateChar.Enabled = false;
            cmdIDSet.Enabled = false;

            pnlMain.Enabled = true;

            #region Register EventHandlers

            foreach (Skill s in ActiveChar.Skills)
            {
                var lvitem = new ListViewItem(s.Symbol);
                lvitem.SubItems.Add(s.Value.ToString());
                lvitem.SubItems.Add(s.FireEvents.ToString());
                lvitem.SubItems.Add(s.EnableBoni.ToString());
                lvitem.SubItems.Add(s.GetBoniNames().Length.ToString());

                lvSkills.Items.Add(lvitem);
                
                //On changing
                s.OnValueChanging += (object sender, SkillEventArgs e) =>
                {
                    consoleCtrl.WriteOutput(string.Format("CHANGE {0} FROM {1} TO {2}\n", e.SkillSymbol, e.OldValue, e.NewValue), Color.White);
                };

                //After changed
                s.OnValueChanged += (object sender, SkillEventArgs e) =>
                {
                    lvitem.SubItems[1].Text = s.Value.ToString();
                    lvitem.SubItems[4].Text = s.GetBoniNames().Length.ToString();
                };

                s.OnSettingBonus += (object sender, SkillEventArgs e) =>
                {
                    consoleCtrl.WriteOutput(string.Format("SET {0} BONUS {1} NAMED {2}\n", lvSkills.SelectedItems[0].Text, e.SkillSymbol, e.NewValue), Color.White);
                };

                s.OnUnsettingBonus += (object sender, SkillEventArgs e) =>
                {
                    consoleCtrl.WriteOutput(string.Format("UNSET{0} BONUS {1} NAMED {2}\n", lvSkills.SelectedItems[0].Text, e.SkillSymbol, e.OldValue), Color.White);
                };
            }

            //On leveling up
            ActiveChar.Skills.OnLevelingUp += (object sender, SkillEventArgs e) =>
            {
                consoleCtrl.WriteOutput(string.Format("LEVEL UP FROM {0} TO {1}\n", e.OldValue, e.NewValue), Color.White);
            };

            //After leveled up
            ActiveChar.Skills.OnLeveledUp += (object sender, SkillEventArgs e) =>
            {
                lvSkills.Items[0].SubItems[1].Text = e.NewValue.ToString();
            };

            #endregion
        }

        private void ResetPanelMain()
        {
            pnlMain.Enabled = false;

            consoleCtrl.ClearOutput();
            lvSkills.Items.Clear();
        }

        private void ShowSkillInfo(string symbol)
        {
            Skill skill = ActiveChar.Skills.GetSkill(symbol);
            StringBuilder message = new StringBuilder();

            message.AppendLine("Symbol: " + skill.Symbol);
            message.AppendLine("Value: " + skill.Value);
            message.AppendLine("Fire events: " + skill.FireEvents);
            message.AppendLine("Enable boni: " + skill.EnableBoni);

            message.AppendLine("Boni:");
            foreach (var bonus in skill.GetBoniNames())
            {
                message.AppendLine("\t" + bonus + " = " + skill.GetBonus(bonus));
            }

            MessageBox.Show(message.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion

        #region Component Event Handling

        private void cmdNewChar_Click(object sender, EventArgs e)
        {
            txtID.Text = "1210000001";
            txtName.Text = "Max Mustermann";
            
            txtName.Enabled = true;
            cmdCreateChar.Enabled = true;
            cmdIDSet.Enabled = true;

            ResetPanelMain();
        }

        private void cmdLevelUp_Click(object sender, EventArgs e)
        {
            ActiveChar.LevelUpManually();
        }

        private void lvSkills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSkills.SelectedIndices.Count != 1) return;

            ShowSkillInfo(lvSkills.SelectedItems[0].Text);
        }

        //Set ID via Console
        private void cmdIDSet_Click(object sender, EventArgs e)
        {
            int customID;

            consoleCtrl.WriteOutput("Enter the custom ID of your Character: ", Color.Green);

            if(!int.TryParse(Console.ReadLine(), out customID) || customID < 1 || customID > 999999)
            {
                consoleCtrl.WriteOutput("ERROR: The custom ID you entered is not valid!\n", Color.Red);
                return;
            }

            txtID.Text = IdentityManager.CreateFullID(IdentityType.Character, 10, customID).ToString();
        }

        private void cmdCreateChar_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtID.Text == "")
            {
                consoleCtrl.WriteOutput("ERROR: You have to fill out the Name and ID fields!\n", Color.Red);
                return;
            }

            SetCharacter(new Character(int.Parse(txtID.Text), txtName.Text));

            consoleCtrl.WriteOutput(string.Format("Created Character object \"{0}\"\n", ActiveChar.Name), Color.White);
        }

        private void lvSkills_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.lvSkills.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        //Open file
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select the file containing a Character object...",
                Multiselect = false
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            Character res = null;
            using (FileStream fs = File.OpenRead(ofd.FileName))
            {
                try
                {
                    res = Character.Deserialize(fs);
                }
                catch
                {
                    consoleCtrl.WriteOutput("ERROR: Couldn't deserialize Character object\n", Color.Red);
                }
                finally
                {
                    SetCharacter(res);
                    consoleCtrl.WriteOutput(string.Format("Successful deserialized the Character object \"{0}\"\n", res.Name), Color.White);
                }
            }
        }

        //Save file
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select the path where to save the Character object..."
            };

            if (sfd.ShowDialog() != DialogResult.OK || sfd.FileName == "") return;

            using (FileStream fs = File.Open(sfd.FileName, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    Character.Serialize(ActiveChar, fs);
                }
                catch
                {
                    consoleCtrl.WriteOutput("ERROR: Couldn't serialize Character object\n", Color.Red);
                }
            }

        }

        //Add Bonus via Console
        private void cmdBonusAdd_Click(object sender, EventArgs e)
        {
            if (lvSkills.SelectedItems.Count != 1)
            {
                consoleCtrl.WriteOutput("ERROR: No skill is selected\n", Color.Red);
                return;
            }

            Skill s = ActiveChar.Skills.GetSkill(lvSkills.SelectedItems[0].Text);
            if(!s.EnableBoni)
            {
                consoleCtrl.WriteOutput("ERROR: Boni are disabled for this skill\n", Color.Red);
                return;
            }

            #region Input

            string bonusName;
            int bonusValue;

            Console.Write("Enter the name of the bonus: ");
            bonusName = Console.ReadLine();

            consoleCtrl.WriteOutput("Enter the value of the bonus: ", Color.Green);
            if (!int.TryParse(Console.ReadLine(), out bonusValue))
            {
                consoleCtrl.WriteOutput("ERROR: The value you intered is invalid\n", Color.Red);
                return;
            }

            #endregion

            if (s.ContainsBonus(bonusName))
            {
                consoleCtrl.WriteOutput("ERROR: The given bonus already exists in this skill\n", Color.Red);
                return;
            }

            s.SetBonus(bonusName, bonusValue);
        }

        //Remove Bonus via Console
        private void cmdBonusRem_Click(object sender, EventArgs e)
        {
            if (lvSkills.SelectedItems.Count != 1)
            {
                consoleCtrl.WriteOutput("ERROR: No skill is selected\n", Color.Red);
                return;
            }

            Skill s = ActiveChar.Skills.GetSkill(lvSkills.SelectedItems[0].Text);
            if (!s.EnableBoni)
            {
                consoleCtrl.WriteOutput("ERROR: Boni are disabled for this skill\n", Color.Red);
                return;
            }

            #region Input

            string bonusName;
            consoleCtrl.WriteOutput("Enter the name of the bonus: ", Color.Green);
            bonusName = Console.ReadLine();

            #endregion
            
            if (!s.ContainsBonus(bonusName))
            {
                consoleCtrl.WriteOutput("ERROR: The given bonus doesn't exists in this skill\n", Color.Red);
                return;
            }

            s.UnsetBonus(bonusName);
        }

        #endregion
    }
}
