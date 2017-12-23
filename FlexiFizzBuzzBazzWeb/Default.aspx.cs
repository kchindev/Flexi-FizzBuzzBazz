using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FlexiFizzBuzzBazzIntf;

namespace FlexiFizzBuzzBazz
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Result.Text = "";
        }

        protected void Run_Click(object sender, EventArgs e)
        {
            // Populate parameters to build Flexi-FizzBuzzBazz
            GoFizzBuzzBazz fizzBuzz = new GoFizzBuzzBazz();
            fizzBuzz.Fizz = GetIntValueFromString(Fizz.Text);
            fizzBuzz.Buzz = GetIntValueFromString(Buzz.Text);
            int startInx = GetIntValueFromString(Start.Text);
            int endInx = GetIntValueFromString(End.Text);
            int bazzValue = GetIntValueFromString(Bazz.Text);
            int predicateSelector = GetIntValueFromString(PredicateSelect.Text);

            // Initialize Result string per Bazz value and predicate selection.
            // Ignore predicate selector if Bazz value not given.
            if (string.IsNullOrEmpty(Bazz.Text.Trim()) && (predicateSelector > 0))
            {
                Result.Text = string.Format("{0}{1}",
                                "** Bazz value not given!\r\n",
                                "** Predicate selection ignored!\r\n\r\n");
                predicateSelector = 0;
            }
            else Result.Text = "";

            // Go according to user selected predicates:
            //  0: no predicate
            //  1: x less than Bazz value
            //  2: x equal to Bazz value
            //  3: x greater than Bazz value
            switch (predicateSelector)
            {
                default:
                    foreach (string s in fizzBuzz.FizzBuzz(startInx, endInx))
                        Result.Text += s + "\r\n";
                    break;
                case 1:
                    foreach (string s in fizzBuzz.FizzBuzzBazz(startInx, endInx, (x => x < bazzValue)))
                        Result.Text += s + "\r\n";
                    break;
                case 2:
                    foreach (string s in fizzBuzz.FizzBuzzBazz(startInx, endInx, (x => x == bazzValue)))
                        Result.Text += s + "\r\n";
                    break;
                case 3:
                    foreach (string s in fizzBuzz.FizzBuzzBazz(startInx, endInx, (x => x > bazzValue)))
                        Result.Text += s + "\r\n";
                    break;
            }

            Result.Focus(); // Show user the generated result string

            Run.Enabled = true; // Enable "Run" button
        }

        // Parse string to get an integer
        private int GetIntValueFromString(string inText)
        {
            int intValue = 0;

            try
            {
                if (inText.Length > 0)
                    intValue = int.Parse(inText.Trim());
            }
            catch { }

            return intValue;
        }
    }
}