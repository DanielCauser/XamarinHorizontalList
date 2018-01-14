using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinHorizontalList.Controls
{
    public class HVRotatedListView : ListView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.Rotation = 270;
        }

        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);
            ((ViewCell)content).View.Rotation = 90;
        }
    }
}
