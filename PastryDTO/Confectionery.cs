using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interlogica.Pastry.DTO
{
    public class Confectionery
    {


        #region Constructors

        public Confectionery()
        {
            Name = "PLACEHOLDER";
            Price = 0.0;
        }
        public Confectionery(string name, double price)
        {
            Name = name;
            Price = price;
            BakingDate = DateTime.Now;
        }

        public Confectionery(string name, double price, DateTime bakingDate) : this(name, price)
        {
            BakingDate = bakingDate;
        }

        #endregion

        #region Fields & Properties

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The confectionery commercial name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the confectionery
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// MSRP
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// It's spoiled and it needs to be removed from selling?
        /// </summary>
        public bool IsSpoiled => DateTime.Now.Subtract(BakingDate.Date).TotalHours > 72; //dopo 3 giorni e' marcia.

        /// <summary>
        /// When it was baked
        /// </summary>
        [Required]
        public DateTime BakingDate { get; set; }

        /// <summary>
        /// Availability
        /// </summary>
        [Required]
        public int AvailableQuantity { get; set; }
        /// <summary>
        /// The current price, related to its age
        /// </summary>
        public double CurrentPrice => GetCurrentPrice();
        #endregion

        #region Methods


        /// <summary>
        /// Update confectionery's price based on its age.
        /// </summary>
        /// <returns></returns>
        protected double GetCurrentPrice()
        {

            var curDay = DateTime.Now;
            var elapsed = curDay.Subtract(BakingDate.Date).TotalHours;

            if (elapsed <= 24)                       // it was baked this day
                return Price;
            else if (elapsed > 24 && elapsed <= 48)   // it was baked yesterday
                return Price * 0.8;
            else if (elapsed > 48 && elapsed <= 72)   // it was baked the day before yesterday
                return Price * 0.2;
            else                                    // it's too old.
            {
                return Price * 0.0;
            }

        }
        #endregion

    }
}
