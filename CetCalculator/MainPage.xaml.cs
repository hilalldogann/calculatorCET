namespace CetCalculator
{
    public partial class MainPage : ContentPage
    {
        double result = 0;
        double firstnumber = 0;
        Operator currentOperator = Operator.None;
        bool isFirstNumberAfterOperator = true;
        private bool isNewCalculation = false;
        public MainPage()
        {
            InitializeComponent();
            Display.Text = "0";
        }

        private async void Button0_Clicked(object sender, EventArgs e)
        {
            await digitClicked(0);
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            firstnumber = 0;
            currentOperator = Operator.None;
            result = 0;
            Display.Text = "0";
        }
        private void DivisionButton_Clicked(object sender, EventArgs e)
        {
            currentOperator = Operator.Divide;
            firstnumber = Convert.ToDouble(Display.Text);
            isFirstNumberAfterOperator = true;
        }


        private void BackSpaceButton_Clicked(object sender, EventArgs e)
        {
            string current = Display.Text;
            if (current.Length > 0)
            {
                Display.Text = current.Substring(0, current.Length - 1);
            }
        }

        private async void Button7_Clicked(object sender, EventArgs e)
        {
            await digitClicked(7);
        }

        private async void Button8_Clicked(object sender, EventArgs e)
        {
            await digitClicked(8);
        }

        private async void Button9_Clicked(object sender, EventArgs e)
        {
            await digitClicked(9);
        }

        

        private async void Button4_Clicked(object sender, EventArgs e)
        {
            await digitClicked(4);
        }

        private async void Button5_Clicked(object sender, EventArgs e)
        {
            await digitClicked(5);
        }

        private async void Button6_Clicked(object sender, EventArgs e)
        {
            await digitClicked(6);
        }

        private void MultiplyButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            await digitClicked(1);
        }

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            await digitClicked(2);
        }

        private async void Button3_Clicked(object sender, EventArgs e)
        {
            await digitClicked(3);
        }

        private void SubtractButton_Clicked(object sender, EventArgs e)
        {

            currentOperator = Operator.Subtract;
            firstnumber = Convert.ToDouble(Display.Text);

            isFirstNumberAfterOperator = true;

        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            double secondNumber = Convert.ToDouble(Display.Text);
            double result = 0;
            switch (currentOperator)
            {
                case Operator.None:
                    break;
                case Operator.Add:
                    result = firstnumber + secondNumber;
                    break;
                case Operator.Subtract:
                    result = firstnumber - secondNumber;
                    break;
                case Operator.Multiply:
                    result = firstnumber * secondNumber;
                    break;
                case Operator.Divide:
                    try
                    {
                        result = firstnumber / secondNumber;
                    }
                    catch (DivideByZeroException)
                    {
                        Display.Text = "Error";
                        return;
                    }
                    break;

                default:
                    break;
            }

            // Set isNewCalculation to true so that firstnumber is only set to result on the next calculation
            isNewCalculation = true;


            Display.Text = result.ToString();
            firstnumber = result;
            currentOperator = Operator.None;
           
        }


        private void AddButton_Clicked(object sender, EventArgs e)
        {
            currentOperator = Operator.Add;
            firstnumber = Convert.ToDouble(Display.Text);
            isFirstNumberAfterOperator = true;
        }


        async Task digitClicked(int digit)
        {
            if (isFirstNumberAfterOperator)
            {
                Display.Text = digit.ToString();
            }
            else
            {
                Display.Text += digit.ToString();
            }

            isFirstNumberAfterOperator = false;
            if (Display.Text.Length > 10)
            {
                await DisplayAlert("Hata", "Sayı maksimum 10 basamaklı olabilir", "Tamam");

                return;
            }

            Display.Text = Display.Text.TrimStart('0');
            if (Display.Text == "") { Display.Text = "0"; }
        }
    }
}