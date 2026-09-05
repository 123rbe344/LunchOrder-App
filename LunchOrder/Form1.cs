namespace LunchOrder
{
    public partial class Form1 : Form
    {
        // Alex Eisenmann
        private struct MainCourse
        {
            public string Name;
            public decimal Price;
            public decimal AddOnPrice;
            public string[] AddOns;
        }

        // Alex Eisenmann
        private readonly MainCourse[] mainCourses = new[]
        {
            new MainCourse
            {
                Name = "Hamburger",
                Price = 6.95m,
                AddOnPrice = 0.75m,
                AddOns = new[] { "Lettuce, tomato, and onions", "Ketchup, mustard, and mayo", "French fries" }
            },
            new MainCourse
            {
                Name = "Pizza",
                Price = 5.95m,
                AddOnPrice = 0.50m,
                AddOns = new[] { "Pepperoni", "Sausage", "Olives" }
            },
            new MainCourse
            {
                Name = "Salad",
                Price = 4.95m,
                AddOnPrice = 0.25m,
                AddOns = new[] { "Croutons", "Bacon bits", "Bread sticks" }
            }
        };

        public Form1()
        {
            InitializeComponent();
        }

        // Alex Eisenmann
        private MainCourse GetSelectedCourse()
        {
            if (rbnPizza.Checked)
            {
                return mainCourses[1];
            }
            if (rbnSalad.Checked)
            {
                return mainCourses[2];
            }
            return mainCourses[0];
        }

        // Alex Eisenmann
        private void ClearTotals()
        {
            txtSubtotal.Text = string.Empty;
            txtSalesTax.Text = string.Empty;
            txtOrderTotal.Text = string.Empty;
        }

        // Alex Eisenmann
        private void ClearAddOns()
        {
            chkAddOn1.Checked = false;
            chkAddOn2.Checked = false;
            chkAddOn3.Checked = false;
        }

        // Alex Eisenmann
        private void rbnMainCourse_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rbn && !rbn.Checked)
            {
                return;
            }

            MainCourse course = GetSelectedCourse();
            gbxAddOns.Text = $"Add-on Items (${course.AddOnPrice:0.00} each)";
            chkAddOn1.Text = course.AddOns[0];
            chkAddOn2.Text = course.AddOns[1];
            chkAddOn3.Text = course.AddOns[2];

            ClearAddOns();
            ClearTotals();
        }

        // Alex Eisenmann
        private void chkAddOn_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
        }

        // Alex Eisenmann
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            MainCourse course = GetSelectedCourse();
            decimal subtotal = course.Price;

            if (chkAddOn1.Checked)
            {
                subtotal += course.AddOnPrice;
            }
            if (chkAddOn2.Checked)
            {
                subtotal += course.AddOnPrice;
            }
            if (chkAddOn3.Checked)
            {
                subtotal += course.AddOnPrice;
            }

            decimal tax = subtotal * 0.0775m;
            decimal total = subtotal + tax;

            txtSubtotal.Text = subtotal.ToString("C");
            txtSalesTax.Text = tax.ToString("C");
            txtOrderTotal.Text = total.ToString("C");
        }

        // Alex Eisenmann
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
