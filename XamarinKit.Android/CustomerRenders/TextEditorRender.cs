
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinKit;
using XamarinKit.Droid.CustomerRenders;

[assembly: ExportRenderer(typeof(LoginEntry), typeof(TextEditorRender))]
namespace XamarinKit.Droid.CustomerRenders
{
    public class TextEditorRender: EntryRenderer
    {
        public TextEditorRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = null;
                
            }
        }
    }
}
