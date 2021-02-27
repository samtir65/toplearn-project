﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace toplearn.Datalayer.Entities.Wallet
{
     public class WalletType
    {
        public WalletType()
        {

        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypId { get; set; }
        [Required]
        [MaxLength(150)]
        public string TypTitle { get; set; }
        #region relation
        public virtual List<Wallet> Wallets { get; set; }

        #endregion

    }

}
