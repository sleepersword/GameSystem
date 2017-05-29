using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSystem.Items;

namespace GameSystem
{
    public static class IdentityManager
    {
        #region Constants

        private const int TYPE_FACTOR = 100000000;
        private const int CHILD_FACTOR =  1000000;

        public const string ROOT_PATH = @".\";

        #endregion

        static IdentityManager()
        {
            ItemManager = new Items.IT_Manager();
        }

        #region Public Methods

        public static IT_Manager ItemManager { get; private set; }

        public static Identity Get(int id)
        {
            if (!ValidateFullID(id)) throw new Exception("ID isn't valid!");

            switch (GetIdentityType(id))
            {
                case IdentityType.Item:
                    return ItemManager.GetItem(id);
                case IdentityType.Character:
                    return null;
                case IdentityType.Effect:
                    return null;
                case IdentityType.Useable:
                    return null;
                case IdentityType.Static:
                    return null;

                default:
                    return null;
            }
        }
        
        public static bool ValidateLightID(int id)
        {
            return ((id < 10000001) || (id > 99999999)) ? false : true;
        }

        public static bool ValidateFullID(int id)
        {
            if ((id < 1110000001) || (id > 1599999999)) return false;

            id = id % (TYPE_FACTOR);

            return ValidateLightID(id);
        }

        public static int CreateFullID(IdentityType type, int childID, int customID)
        {
            if (childID < 10 || customID < 1 || childID > 99 || customID > 999999 ) return -1;

            int id = ((int)type * TYPE_FACTOR) + (childID * CHILD_FACTOR) + customID;

            if (ValidateFullID(id))
            {
                return id;
            }
            else return -1;
        }

        public static int CreateLightID(int childID, int customID)
        {
            if (childID < 10 || customID < 1 || childID > 99 || customID > 999999) return -1;

            int id = (childID * CHILD_FACTOR) + customID;

            if (ValidateLightID(id))
            {
                return id;
            }
            else return -1;
        }

        public static IdentityType GetIdentityType(int id)
        {
            return (IdentityType)(id / TYPE_FACTOR);
        }

        public static int GetChildID(int id)
        {
            return ((id % TYPE_FACTOR) / CHILD_FACTOR);
        }

        public static int GetCustomID(int id)
        {
            return ((id % TYPE_FACTOR) % CHILD_FACTOR);
        }

        #endregion
    }

    public enum IdentityType
    {
        Item = 11,
        Character = 12,
        Static = 13,
        Useable = 14,
        Effect = 15
    }
}
