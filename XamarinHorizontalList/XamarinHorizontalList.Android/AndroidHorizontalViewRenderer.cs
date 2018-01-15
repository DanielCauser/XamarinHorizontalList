using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinHorizontalList.Droid;
using XamarinHorizontalList.Renderers;

[assembly: ExportRenderer(typeof(HorizontalViewRenderer), typeof(AndroidHorizontalViewRenderer))]
namespace XamarinHorizontalList.Droid
{
	public class AndroidHorizontalViewRenderer : ViewRenderer<HorizontalViewRenderer, RecyclerView>
	{
	}
}