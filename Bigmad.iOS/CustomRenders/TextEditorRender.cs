using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinKit;
using XamarinKit.iOS.CustomRenders;


[assembly: ExportRenderer(typeof(LoginEntry), typeof(TextEditorRender))]
namespace XamarinKit.iOS.CustomRenders
{

    public class TextEditorRender: EntryRenderer
    {
        public TextEditorRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
