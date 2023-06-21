using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Part3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static List<inputStorage> store = new List<inputStorage>();//this is generic list that takes in the input from the user-input
		private string recipename = "";
		private string recipename = "";//Those are variables that will be used to search and display in the below methods
		private int ingredTime = 0;
		public string findRecipe="";
		double factor = 0;
		public string Recipename { get => recipename; set => recipename = value; }
		public int IngredTime { get => ingredTime; set => ingredTime = value; }
		int count = 1;

		public MainWindow()
		{
			InitializeComponent();
		}



		private void gridding(object sender, RoutedEventArgs e)//this method is used for the main page to display the message on load of page/grid
		{
			quoting.Content = "This app is for storing your recipes and displaying";

		}


		private void EnterRecipe_method(object sender, RoutedEventArgs e)
		{

			EnteingRecipe.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Visible;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;
			listBox.Items.Clear();

		}

		private void viewRecipe_method(object sender, RoutedEventArgs e)
		{
			viewRecipe.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Collapsed;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;

			display();
			stepsListingChecked();
			//listBox.Items.Clear();
		}

		private void QuantiyChange_method(object sender, RoutedEventArgs e)
		{
			QuantityChanging.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Visible;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;
			listBox.Items.Clear();
		}

		private void Restart_method(object sender, RoutedEventArgs e)
		{
			Restarted.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Visible;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;
			listBox.Items.Clear();
		}

		private void CleanAll_method(object sender, RoutedEventArgs e)
		{
			cleaned.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Visible;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;

		}

		private void stopAll(object sender, RoutedEventArgs e)
		{
			GoodBye.Visibility = Visibility.Visible;
			MainEvents.Visibility = Visibility.Visible;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			if (Bye.IsPressed)
			{
				Close();
			}
			listBox.Items.Clear();
		}

		private void searchRecipe_forQuan_method(object sender, RoutedEventArgs e)
		{
			 findRecipe = SearchrecipeName.Text.ToLower();

			foreach (var item in store)
			{
				if (item.RecipeName.Equals(findRecipe))
				{
					MessageBox.Show("found");
					quantiyChange_grid.Visibility = Visibility.Visible;
				}
				else
				{
					MessageBox.Show("not found", "error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}

		private void QuantityChanging_Loaded(object sender, RoutedEventArgs e)
		{
			ComboBox factors = new ComboBox();
			factors.Items.Add("2");
			factors.Items.Add("0.5");
			factors.Items.Add("3");

			// Adding this ComboBox to the form
			//Controls.Add(mybox);
		}

		private void restarted_method(object sender, RoutedEventArgs e)
		{
			foreach (var item in store)
			{
				if (factor == 0.5)
				{
					item.IngredQuantity *= 2;
					MessageBox.Show("changed back from  half");

				}
				else if (factor == 2)
				{
					item.IngredQuantity /= 2;
					MessageBox.Show("changed back from  double");


				}
				else if (factor == 3)
				{
					item.IngredQuantity /= 3;
					MessageBox.Show("changed back from  triple");


				}
			}


		}

		private void deleted_method(object sender, RoutedEventArgs e)
		{
			store.Clear();
			listBox.Items.Clear();
			MessageBox.Show("everything has been deleted");
		}

		

		private void hide2(object sender, RoutedEventArgs e)
		{
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;
		}

		private void homeset(object sender, MouseEventArgs e)
		{
			MainEvents.Visibility = Visibility.Visible;
			EnteingRecipe.Visibility = Visibility.Collapsed;
			viewRecipe.Visibility = Visibility.Collapsed;
			QuantityChanging.Visibility = Visibility.Collapsed;
			Restarted.Visibility = Visibility.Collapsed;
			cleaned.Visibility = Visibility.Collapsed;
			GoodBye.Visibility = Visibility.Collapsed;
			listBox.Items.Clear();
		}
		private void sendStartData(object sender, RoutedEventArgs e)
		{
			Recipename = recipenames.Text;
			try
			{
				IngredTime = Convert.ToInt32(ingrNum.Text);

			}
			catch (Exception a)
			{
				MessageBox.Show("Error found: ","error",MessageBoxButton.OK,MessageBoxImage.Error);
			}
			MessageBox.Show($"Recipe name: {Recipename},\n let begin");

		}

		private void RecipeLists(object sender, RoutedEventArgs e)//this method is for enter the details of the recipe
		{


			numofIngres.Content = $"Number of {count}:{IngredTime}";
			recipeName.Content = $"Recipe name: {Recipename}";
			enterRecpie.Visibility = Visibility.Collapsed;
			if (count != IngredTime)
			{
				store.Add(new inputStorage(Recipename, ansingredName.Text.ToLower(), Convert.ToDouble(ansIngredQuan.Text), ansUnitMeasure.Text.ToLower(), ansFood.Text.ToLower(), Convert.ToDouble(anscalarius.Text), ansSteps.Text.ToLower()));

				MessageBox.Show("there are still more ingredients to enter", "Configure", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				ansingredName.Text = string.Empty;
				ansIngredQuan.Text = string.Empty;
				ansUnitMeasure.Text = string.Empty;
				ansFood.Text = string.Empty;
				anscalarius.Text = string.Empty;
				ansSteps.Text = string.Empty;
				numofIngres.Content = $"Number of {count}:{IngredTime}";
			}
			else
			{
				MessageBox.Show("Done");
				try
				{
					store.Add(new inputStorage(Recipename.ToLower(), ansingredName.Text.ToLower(), Convert.ToDouble(ansIngredQuan.Text), ansUnitMeasure.Text.ToLower(), ansFood.Text, Convert.ToDouble(anscalarius.Text), ansSteps.Text.ToLower()));

				}
				catch (Exception a)
				{

					MessageBox.Show($"Error found: {a.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error); ;
				}

				count = 1;
				ansingredName.Text = string.Empty;
				ansIngredQuan.Text = string.Empty;
				ansUnitMeasure.Text = string.Empty;
				ansFood.Text = string.Empty;
				anscalarius.Text = string.Empty;
				ansSteps.Text = string.Empty;



			}
			count++;
			MessageBox.Show("Count incremented");

			enterRecpie.Visibility = Visibility.Visible;
		}








		public void display()
		{

			foreach (var item in store)
			{
				listBox.Items.Add("Recipe Name: " + item.RecipeName);
				listBox.Items.Add("************************************");
				listBox.Items.Add("Ingredient Name: " + item.IngredName);
				listBox.Items.Add("Ingredient Quantity: " + item.IngredQuantity);
				listBox.Items.Add("Unit of Measurement: " + item.UnitfMeasurement);
				listBox.Items.Add("Food group: " + item.FoodGroup);
				listBox.Items.Add("Calaius: " + item.Calaries);
			}
			listBox.Items.Add("*************************************");
			
		
		}

		private void changingQuans(object sender, RoutedEventArgs e)
		{
			 factor = Convert.ToDouble(factors.Text);
			foreach (var item in store)
			{
				if (item.RecipeName.Equals(findRecipe))
				{
					if (factor ==0)
					{
						changequanList.Items.Add("Recipe name: "+item.RecipeName);
						changequanList.Items.Add("Ingredient Quantity: "+item.IngredQuantity);
						MessageBox.Show("no changes made ");
					}else if (factor ==0.5)
					{
						item.IngredQuantity *= factor;
						changequanList.Items.Add("Recipe name: " + item.RecipeName);
						changequanList.Items.Add("Ingredient Quantity: " + item.IngredQuantity);
						MessageBox.Show("changed by half");
					}
					else if (factor ==2)
					{
						item.IngredQuantity *= factor;
						changequanList.Items.Add("Recipe name: " + item.RecipeName);
						changequanList.Items.Add("Ingredient Quantity: " + item.IngredQuantity);
						MessageBox.Show("changed by Double");

					}
					else if (factor== 3)
					{
						item.IngredQuantity *= factor;
						changequanList.Items.Add("Recipe name: " + item.RecipeName);
						changequanList.Items.Add("Ingredient Quantity: " + item.IngredQuantity);
						MessageBox.Show("changed by Triple");

					}

				}
				

			}
		}

		private void goodbye_method(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void stepsDisplays(object sender, RoutedEventArgs e)
		{
			
		}
		public void stepsListingChecked()
		{


			foreach (var item in store)
			{
				CheckBox box = new CheckBox();

				//boxs.Content = item.steps;
				box.Name = item.RecipeName.Replace(" ","");
				box.Content = item.steps;
				
				liststeps.Items.Add(box);
			
			}
			
		}
	}
}
