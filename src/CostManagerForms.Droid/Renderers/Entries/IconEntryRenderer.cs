using System;
using Android.Runtime;
using App = Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Path = System.IO.Path;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using CostManagerForms.UI.Renderers.Entries;
using CostManagerForms.Droid.Renderers.Entries;

[assembly: ExportRenderer(typeof(IconEntry), typeof(IconEntryRenderer))]
namespace CostManagerForms.Droid.Renderers.Entries
{
    [Preserve(AllMembers = true)]
    public class IconEntryRenderer : EntryRenderer
    {
        private IconEntry element;

        public IconEntryRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (IconEntry)this.Element;
            Control.EditorAction += Control_EditorAction;

            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private void Control_EditorAction(object sender, Android.Widget.TextView.EditorActionEventArgs e)
        {
            if (element.ReturnType != ReturnType.Next)
            {
                element.Unfocus();
            }

            element.FocusView?
                .Focus();
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage.ToLower(), "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }
    }
}
