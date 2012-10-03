using System;
using Android.Dialog;
using Android.OS;
using MonoCross.Navigation;

namespace MonoCross.Droid
{
    public abstract class MXDialogFragmentView<T> : DialogListFragment, IMXView
    {
        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // fetch the model before rendering!!!
            Model = (T)MXDroidContainer.ViewModels[typeof(T)];

            // render the model within the view
            Render();
        }

        public T Model { get; set; }
        public Type ModelType { get { return typeof(T); } }
        public abstract void Render();
        public void SetModel(object model)
        {
            Model = (T)model;
        }

        public event ModelEventHandler ViewModelChanged;
        public virtual void OnViewModelChanged(object model) { }
        public void NotifyModelChanged() { if (ViewModelChanged != null) ViewModelChanged(Model); }
    }
}