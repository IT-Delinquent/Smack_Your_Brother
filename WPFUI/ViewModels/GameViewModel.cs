using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    /// <summary>
    /// Includes the logic for the game screen
    /// </summary>
    public class GameViewModel : Screen
    {
        #region Private backing fields

        #region Game private fields

        /// <summary>
        /// Holds the points per smack value
        /// </summary>
        private double _pointPerSmack = 1;

        /// <summary>
        /// Holds the current balance for the user
        /// </summary>
        private double _balance = 100;

        #endregion

        #region ExtraHand private fields

        /// <summary>
        /// Holds the amount of extra hand upgrades
        /// </summary>
        private double _extraHandQTY = 0;
        
        /// <summary>
        /// Holds the reward added to the per smack value when
        /// buying an extra hand
        /// </summary>
        private int _extraHandReward = 2;

        /// <summary>
        /// The price of an extra hand when first starting the game
        /// </summary>
        private double _extraHandPrice = 10;

        #endregion

        #region Stick private fields

        /// <summary>
        /// Holds the amount of stick upgrades
        /// </summary>
        private double _stickQTY = 0;

        /// <summary>
        /// Holds the reward added to the per smack value
        /// when buying a stick
        /// </summary>
        private int _stickReward = 5;

        /// <summary>
        /// The price of a stick when first starting the game
        /// </summary>
        private double _stickPrice = 40;

        #endregion

        #endregion

        #region Game public fields

        /// <summary>
        /// Used to hold the total balance
        /// </summary>
        public double Balance
        {
            get { return _balance; }
            set 
            { 
                _balance = value;
                NotifyOfPropertyChange(() => Balance);
                NotifyOfPropertyChange(() => CanExtraHand);
                NotifyOfPropertyChange(() => CanStick);
            }
        }

        /// <summary>
        /// Used to hold the amount of pointed that are rewarded per click
        /// </summary>
        public double PointPerSmack
        {
            get { return _pointPerSmack; }
            set
            {
                _pointPerSmack = value;
                NotifyOfPropertyChange(() => PointPerSmack);
            }
        }

        #endregion

        #region ExtraHand public fields

        /// <summary>
        /// Holds to quantity of extra hand's that are owned
        /// </summary>
        public double ExtraHandQTY
        {
            get { return _extraHandQTY; }
            set 
            { 
                _extraHandQTY = value;
                NotifyOfPropertyChange(() => ExtraHandQTY);
            }
        }

        /// <summary>
        /// Holds the current price of an extra hand
        /// </summary>
        public double ExtraHandPrice
        {
            get { return _extraHandPrice; }
            set 
            { 
                _extraHandPrice = value;
                NotifyOfPropertyChange(() => ExtraHandPrice);
            }
        }

        /// <summary>
        /// Decides whether the buy button for an extra hand is 
        /// enabled or disabled
        /// </summary>
        public bool CanExtraHand => Balance > ExtraHandPrice;

        #endregion

        #region Stick public fields

        /// <summary>
        /// Holds to quantity of stick's that are owned
        /// </summary>
        public double StickQTY
        {
            get { return _stickQTY; }
            set
            {
                _stickQTY = value;
                NotifyOfPropertyChange(() => StickQTY);
            }
        }

        /// <summary>
        /// Holds the current price of a stick
        /// </summary>
        public double StickPrice
        {
            get { return _stickPrice; }
            set
            {
                _stickPrice = value;
                NotifyOfPropertyChange(() => StickPrice);
            }
        }

        /// <summary>
        /// Decides whether the buy button for a stick is 
        /// enabled or disabled
        /// </summary>
        public bool CanStick => Balance > StickPrice;

        #endregion

        #region Game public methods

        /// <summary>
        /// Performes the actions when the player presses the buy button for
        /// an extra hand
        /// </summary>
        public void ExtraHand()
        {
            //Take off the price of the extra hand
            Balance -= ExtraHandPrice;
            //Increase the quantity owned
            ExtraHandQTY++;
            //Update the points per smack
            PointPerSmack += _extraHandReward;
            //Update the price for an extra hand
            ExtraHandPrice += Math.Round((ExtraHandQTY * 2));
            //Update if the user can purchase another hand
            NotifyOfPropertyChange(() => CanExtraHand);
        }

        /// <summary>
        /// Performes the actions when the player presses the buy button for
        /// a stick
        /// </summary>
        public void Stick()
        {
            //Take off the price fo the stick
            Balance -= StickPrice;
            //Increase the quantity owned
            StickQTY++;
            //Update the points per smack
            PointPerSmack += _stickReward;
            //Update the price for a stick
            StickPrice += Math.Round((StickQTY * 5));
            //Update if the user can purchase another hand
            NotifyOfPropertyChange(() => CanStick);
        }

        /// <summary>
        /// Performs actions when the player presses 
        /// the smack button
        /// </summary>
        public void Smack()
        {
            Balance += PointPerSmack;
        }

        #endregion
    }
}