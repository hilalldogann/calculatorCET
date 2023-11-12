

namespace CetCalculator
{
    public partial class MainPage : ContentPage
    {
        double result = 0;
        double firstnumber = 0;
        Operator currentOperator = Operator.None;
        bool isFirstNumberAfterOperator = true;

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
            //Homework
            firstnumber = 0;
            currentOperator = Operator.None;
            result = 0;
            Display.Text = "0";
        }

        private void BackSpaceButton_Clicked(object sender, EventArgs e)
        {
            //Homework
            //"289898" => substring(
            
            Display.Text=Display.Text.Substring(0, Display.Text.Length - 1);
            if(Display.Text.Length ==0) Display.Text = "0";
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

        private void DivisionButton_Clicked(object sender, EventArgs e)
        {

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
          await  digitClicked(2);
        }

        private async void Button3_Clicked(object sender, EventArgs e)
        {
            await digitClicked(3);
        }

        private void SubtractButton_Clicked(object sender, EventArgs e)
        {
            
            currentOperator = Operator.Subtract;
            firstnumber = Convert.ToDouble(Display.Text);
           
            isFirstNumberAfterOperator= true;

        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            double secondNumber= Convert.ToDouble(Display.Text);
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
                    break;
                case Operator.Divide:
                    break;
                default:
                    break;
            }
            Display.Text = result.ToString();
            firstnumber= result; //??
            currentOperator= Operator.None;

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            currentOperator = Operator.Add;
            firstnumber = Convert.ToDouble(Display.Text);
            isFirstNumberAfterOperator= true;
        }

       
        async Task digitClicked(int digit)
        {
            //Homework
            //Should work in a correct way. eg. after operator click, it replace current value
            string current = "";
            
            current =  isFirstNumberAfterOperator ? digit.ToString() :  Display.Text + digit.ToString();

            //if (isFirstNumberAfterOperator)
            //{
            //    current = digit.ToString();
            //} else
            //{
            //    current = Display.Text + digit.ToString();
            //}
            
            
            
            isFirstNumberAfterOperator = false;
            if(current.Length>10)
            {
                await DisplayAlert("Hata", "Sayı maksimum 10 basamaklı olabilir", "Tamam");

                return;
            }
            
            
            Display.Text = current.TrimStart( '0' );
            if (Display.Text == "") { Display.Text = "0"; }
        }
    }
}