﻿using System;
using BankEntites.BLL.Entities;
using BankEntites.BLL.Interfaces;


namespace BankEntites.DAL.Entities
{
    /// <summary>
    /// Represents golden bank account abstraction and provides it's methods
    /// </summary>
    [Serializable]
    public class GoldenAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the GoldenAccount class.
        /// </summary>
        /// <param name="accOwner"></param>
        /// <returns>instance</returns>
        public GoldenAccount(AccountOwner accOwner, IidGenerator idGenerator, IPointsCounter counter) : base(accOwner, idGenerator, counter) { }

        /// <summary>
        /// Validates deposit operation for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected override void ValidateDeposit(decimal amount)
        {
            if (amount + this.balance > 100000)
                throw new ArgumentException("Too big deposit amount, limit for this type of account is 10000");
        }

        /// <summary>
        /// Validates withdraw operation for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected override void ValidateWithdraw(decimal amount)
        {
            if (this.balance - amount < -5000)
                throw new ArgumentException("Can't perform withdraw amount, negative limit for this type of account is -500");
        }

        /// <summary>
        /// Updates bonus points for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected override void UpdateBonusPoints(decimal amount)
        {
            bonusPoints = CountPoint(balance, amount, 25, bonusPoints);
        }
    }
}
