using System.Web;
using System.Web.Optimization;

namespace Core.WebAplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            // Jquery
            bundles.Add(new ScriptBundle("~/Scripts/Jquery")
                    .Include("~/Scripts/jquery-3.3.1.min.js")
                    .Include("~/Scripts/jquery-ui.js")
                );

            // Bootstrap
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap")
                .Include("~/Scripts/bootstrap.min.js")
            );

            bundles.Add(new ScriptBundle("~/Scripts/BootstrapPaginator")
                .Include("~/Plugins/bootstrap-paginator/js/bootstrap-paginator.js")
            );

            // Lodash
            bundles.Add(new ScriptBundle("~/Scripts/Lodash")
                .Include("~/Scripts/lodash.min.js")
            );

            // AdminLte
            bundles.Add(new ScriptBundle("~/Scripts/AdminLte")
                .Include("~/Plugins/admin-lte/js/adminlte.min.js")
                .Include("~/Scripts/Common/Common.js")
                .Include("~/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
            );

            // AjaxForm
            bundles.Add(new ScriptBundle("~/Scripts/AjaxForm")
                .Include("~/Scripts/ajax.common.js", "~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.validate.hooks.js")
            );
            // dynatree
            bundles.Add(new ScriptBundle("~/Scripts/Dynatree").Include(
                "~/Scripts/jquery.dynatree.js"));

            // typeahead
            bundles.Add(new ScriptBundle("~/Scripts/typeahead").Include(
                "~/Scripts/typeahead.bundle.js"));

            // table admin
            bundles.Add(new ScriptBundle("~/Plugins/AdminLteTableJs")
                .Include("~/Plugins/admin-lte/js/datatables.net/jquery.dataTables.min.js")
                .Include("~/Plugins/admin-lte/js/datatables.net-bs/js/dataTables.bootstrap.min.js")
            );


            bundles.Add(new ScriptBundle("~/Plugins/DropDownSelect2Js")
                .Include("~/Plugins/select2/dist/js/select2.full.min.js")
            );

            bundles.Add(new ScriptBundle("~/Plugins/TreeTableJs")
                .Include("~/Plugins/treegrid/jquery.treegrid.js")
            );
            bundles.Add(new ScriptBundle("~/Plugins/TreeDropDownJs").Include(
                "~/Plugins/jqwidgets/scripts/demos.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxcore.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxdata.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxbuttons.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxscrollbar.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxpanel.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxtree.js",
                "~/Plugins/jqwidgets/jqwidgets/jqxdropdownbutton.js"
            ));

            // Login
            bundles.Add(new ScriptBundle("~/Scripts/Login")
                .Include("~/Scripts/jquery-3.3.1.min.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/jquery.validate.hooks.js")
            );
            // End Scripts

            // CSS
            // bootstrap
            bundles.Add(new StyleBundle("~/Content/Normalize").
                Include("~/Content/normalize.css")
            );
            // bootstrap
            bundles.Add(new StyleBundle("~/Content/Bootstrap").
                Include("~/Content/bootstrap.min.css")
            );
            bundles.Add(new StyleBundle("~/Content/BootstrapPaginator")
                .Include("~/Plugins/bootstrap-paginator/css/bootstrap-paginator.css")
            );
            //FontAwesome
            bundles.Add(new StyleBundle("~/Content/FontAwesome").
                Include("~/Content/font-awesome.min.css")
            );
            //ionicons
            bundles.Add(new StyleBundle("~/Content/Ionicons").
                Include("~/Content/ionicons.min.css")
            );

            //adminlte
            bundles.Add(new StyleBundle("~/Content/AdminLte")
                .Include("~/Plugins/admin-lte/css/AdminLTE.min.css")
                .Include("~/Plugins/admin-lte/css/skins/skin-blue.min.css")
                .Include("~/Plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
                .Include("~/Plugins/bootstrap-daterangepicker/daterangepicker.css")
                .Include("~/Plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css")
                    );

            //table admin
            bundles.Add(new StyleBundle("~/Plugins/AdminLTETableCss")
                .Include("~/Plugins/admin-lte/js/datatables.net-bs/css/dataTables.bootstrap.min.css")
                .Include("~/Content/Common/Common.css")
            );

            //DropDownList select2
            bundles.Add(new StyleBundle("~/Plugins/DropDownSelect2Css").
                Include("~/Plugins/select2/dist/css/select2.min.css")
            );

            bundles.Add(new StyleBundle("~/Plugins/TreeTableCss").
                Include("~/Plugins/treegrid/jquery.treegrid.css")
            );

            bundles.Add(new StyleBundle("~/Plugins/TreeDropDownCss").Include(
                "~/Plugins/jqwidgets/jqwidgets/styles/jqx.base.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Plugins").Include(
                "~/Plugins/confirm/jquery-confirm.css"
                , "~/Plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css"
                , "~/Plugins/timepicker/bootstrap-timepicker.min.css"
                , "~/Plugins/bootstrap-daterangepicker/daterangepicker.css"

            ));
            bundles.Add(new StyleBundle("~/Plugins/iCheck/ICheckCss")
             .Include("~/Plugins/iCheck/all.css"));
            // End CSS

            //Upload
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/Plugins/pickerJs").Include(
                        "~/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/plugins/timepicker/bootstrap-timepicker.min.js",
                        "~/Plugins/iCheck/icheck.min.js"
                        ));


            bundles.Add(new ScriptBundle("~/Plugins/iCheck/ICheckJs")
             .Include("~/Plugins/iCheck/icheck.min.js"));
            //ionicons
            bundles.Add(new StyleBundle("~/Content/Login")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Plugins/admin-lte/css/AdminLTE.min.css")
                .Include("~/Content/Common/Common.css")
                    );
        }
    }
}
