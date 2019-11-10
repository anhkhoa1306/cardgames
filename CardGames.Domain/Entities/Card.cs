using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardGames.Domain.DatabaseEnum;

namespace CardGames.Domain.Entities
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public CardName CardName { get; set; }
        public CardSuite CardSuite { get; set; }
    }
}