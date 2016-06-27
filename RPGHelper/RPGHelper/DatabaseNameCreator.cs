﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGHelper
{
    public partial class DatabaseNameCreator : UserControl
    {
        #region Callbacks
        /// <summary>
        /// Register a callback delegate for ExitButton.Click event 
        /// </summary>
        private event myActionDelegate registerExitCreation;

        /// <summary>
        /// Register a callback delegate for next step of creation button
        /// </summary>
        private event myActionDelegateWithDatabaseName registerNextStepCreation;
     
        #endregion


        //Delegates
        public delegate void myActionDelegate();
        public delegate void myActionDelegateWithDatabaseName(string databaseName);

        private List<char> notAllowedCharacters;

        /// <summary>
        /// Control which role is to make get a database name for newly created session
        /// </summary>
        /// <param name="exit">Delegate for exiting creation</param>
        /// <param name="nextStep">Delegate for next step of creation</param>
        /// <param name="startingName">Starting value for session name, default: ""</param>
        public DatabaseNameCreator(myActionDelegate exit, myActionDelegateWithDatabaseName nextStep, string startingName = "")
        {
            InitializeComponent();
            notAllowedCharacters = new List<char>(new char[] { ' ', '_', '*' });
            registerExitCreation = exit;
            registerNextStepCreation = nextStep;
            textBoxDatabaseName.Text = startingName;
        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExitCreation();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            if(textBoxDatabaseName.Text.Trim()=="")
            {
                MessageBox.Show("Session name can not be blank!", "Invalid session name", MessageBoxButtons.OK);
                return;
            }
            try
            {
                if(DBCreator.doesDatabaseExists("RPGH"+textBoxDatabaseName.Text))
                {
                    MessageBox.Show("Session already exists! Use diffrent name!", "Bad session name", MessageBoxButtons.OK);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error was encountered! Erron message: " + ex.Message, "Error in connecting to server", MessageBoxButtons.OK);
                return;
            }
            registerNextStepCreation(textBoxDatabaseName.Text);
        }

        private void textBoxDatabaseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(notAllowedCharacters.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
