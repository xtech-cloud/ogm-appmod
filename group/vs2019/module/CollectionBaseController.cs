
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionBaseController: Controller
    {

        protected CollectionView view {get;set;}

        protected override void preSetup()
        {
            view = findView(CollectionView.NAME) as CollectionView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.CollectionController");
        }
    }
}
