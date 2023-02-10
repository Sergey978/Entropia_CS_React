using System;
using System.Collections.Generic;

namespace Entropia_CS_React.Domain.Models
{
    /*
    CREATE TABLE [dbo].[CustomItems](
      +  [Id] [int] IDENTITY(1,1) NOT NULL,
      +  [Name] [nvarchar](50) NOT NULL,
      +  [Price] [decimal](5, 2) NOT NULL,
        [UserId] [nvarchar](128) NOT NULL,
      +  [Chosed] [bit] NULL,
      +  [BeginQuantity] [int] NULL,
      +  [Markup] [decimal](6, 2) NULL,
      +  [PurchasePrice] [decimal](8, 2) NULL,
      +  [Step] [int] NULL,
    PRIMARY KEY CLUSTERED
    (
        [Id] ASC

    */


    public class CustomItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
        public int BeginQuantity { get; set; }
        public decimal Markup { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Step { get; set; }
        public int AccountId { get; set; }
    }
}
