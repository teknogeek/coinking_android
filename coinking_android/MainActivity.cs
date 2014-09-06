using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace coinking_android
{
	[Activity (Label = "coinking_android",  MainLauncher = true)]			
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Create your application here
			EditText apiKeyEditText = FindViewById<EditText>(Resource.Id.apiKey);
			Button loadButton = FindViewById<Button>(Resource.Id.loadAPI);
			ListView apiInfoListView = FindViewById<ListView>(Resource.Id.apiInfoList);

			string apiKey = string.Empty;
				
			loadButton.Click += (object sender, EventArgs e) => 
			{
				apiKey = apiKeyEditText.Text;

				if(!String.IsNullOrWhiteSpace(apiKey))
				{
					List<string> apiInfo = coinking_android.apiParser.getApiInfo(apiKey);
					apiInfoListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, apiInfo);
				}
			};
		}
	}
}