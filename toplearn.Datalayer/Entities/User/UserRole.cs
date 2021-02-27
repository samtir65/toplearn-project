using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace toplearn.Datalayer.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {

        }

        [Key]
        public int UR_ID { get; set; }
        

        public int UserID { get; set; }
      
        public int RolID { get; set; }

        #region relations
        public virtual User user { get; set; }
        public virtual Role role { get; set; }

        #endregion
    }
}
