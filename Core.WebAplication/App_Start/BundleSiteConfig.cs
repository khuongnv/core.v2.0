using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Core.WebAplication
{
    public class BundleSiteConfig
    {
        public static void RegisterSiteBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/assets/scripts/jquery")
                .Include("~/assets/scripts/jquery-2.1.4.js")
                .Include("~/assets/scripts/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/assets/scripts/jqueryval")
                .Include("~/assets/scripts/jquery.validate.*"));

            bundles.Add(new ScriptBundle("~/assets/scripts/unobtrusive")
                 .Include("~/assets/scripts/ajax.common.js")
                .Include("~/assets/scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/assets/scripts/modernizr")
                .Include("~/assets/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/assets/scripts/jqueryplugin")
                .Include("~/assets/scripts/jquery-ui.custom.min.js")
                .Include("~/assets/scripts/jquery.ui.touch-punch.min.js")
                .Include("~/assets/scripts/jquery.easypiechart.min.js")
                .Include("~/assets/scripts/jquery.sparkline.index.min.js")
                .Include("~/assets/scripts/jquery.flot.min.js")
                .Include("~/assets/scripts/jquery.flot.pie.min.js")
                .Include("~/assets/scripts/jquery.flot.resize.min.js")
                .Include("~/assets/scripts/jquery.hotkeys.index.min.js")
                .Include("~/assets/scripts/jquery.bootstrap-duallistbox.min.js")
                .Include("~/assets/scripts/jquery.raty.min.js")
                .Include("~/assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
                .Include("~/assets/plugins/iCheck/icheck.min.js")
                .Include("~/assets/scripts/Common/Common.js")
              );

            bundles.Add(new ScriptBundle("~/assets/scripts/bootstrap")
                .Include("~/assets/scripts/bootstrap.min.js")
                );

            bundles.Add(new ScriptBundle("~/assets/scripts/bootstrapplugin")
                .Include("~/assets/scripts/bootstrap-tag.min.js")
                .Include("~/assets/scripts/bootstrap-wysiwyg.min.js")
                .Include("~/assets/scripts/bootstrap-datepicker.min.js")
                .Include("~/assets/scripts/bootstrap-datetimepicker.min.js")
                .Include("~/assets/scripts/bootstrap-timepicker.min.js")
                .Include("~/assets/scripts/bootstrap-multiselect.min.js")
                .Include("~/assets/scripts/spinbox.min.js")
                .Include("~/assets/scripts/bootstrap-paginator.js")
                );

            bundles.Add(new ScriptBundle("~/assets/scripts/chosen")
                .Include("~/assets/scripts/chosen.jquery.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/scripts/select2")
               .Include("~/assets/scripts/select2.min.js")
               );
            bundles.Add(new ScriptBundle("~/assets/scripts/moment")
                .Include("~/assets/scripts/moment.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/scripts/DateTimeJs")
                .Include("~/assets/scripts/datetime/daterangepicker.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/scripts/button").Include(
                "~/assets/scripts/buttons.flash.min.js",
                "~/assets/scripts/buttons.html5.min.js",
                "~/assets/scripts/buttons.print.min.js",
                "~/assets/scripts/buttons.colVis.min.js"
            ));

            bundles.Add(new ScriptBundle("~/assets/scripts/dataTable").Include(
                "~/assets/scripts/jquery.dataTables.min.js",
                "~/assets/scripts/jquery.dataTables.bootstrap.min.js",
                "~/assets/scripts/dataTables.buttons.min.js",
                "~/assets/scripts/dataTables.select.min.js"
            ));

            bundles.Add(new ScriptBundle("~/assets/scripts/toast/toastJs")
                .Include("~/assets/scripts/toast/toastr.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/scripts/bootbox/bootboxJs")
                .Include("~/assets/scripts/bootbox/bootbox.all.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/libs/fancytree/dist/fancytreeJs")
                .Include("~/assets/libs/fancytree/dist/jquery.fancytree-all.min.js")
                .Include("~/assets/libs/fancytree/dist/jquery.fancytree-all-deps.min.js")
                );

            bundles.Add(new ScriptBundle("~/assets/scripts/plugins")
                .Include("~/assets/scripts/tree.min.js")
                .Include("~/assets/scripts/jstree.min.js")
                .Include("~/assets/scripts/ace-elements.min.js")
                .Include("~/assets/scripts/ace.min.js")
                );
            bundles.Add(new ScriptBundle("~/assets/scripts/site")
                .Include("~/assets/scripts/Site.js")
                );
            //
            // CSS
            //
            bundles.Add(new StyleBundle("~/assets/css/jqueryui")
               .Include("~/assets/css/jquery-ui.custom.min.css")
               );
            bundles.Add(new StyleBundle("~/assets/css/bootstrap")
                .Include("~/assets/css/bootstrap.min.css")
                );
            bundles.Add(new StyleBundle("~/assets/css/fontAwesome")
              .Include("~/assets/css/font-awesome.min.css")
              );
            bundles.Add(new StyleBundle("~/assets/css/fontGoogle")
             .Include("~/assets/css/fonts.googleapis.com.css")
             );

            bundles.Add(new StyleBundle("~/assets/css/DateTimeCss")
                .Include("~/assets/css/datetime/daterangepicker.min.css")
                );
            bundles.Add(new StyleBundle("~/assets/libs/fancytree/dist/skin-win8/FancyTreeJs")
                .Include("~/assets/libs/fancytree/dist/skin-win8/ui.fancytree.min.css")
                );

            bundles.Add(new StyleBundle("~/assets/css/plugins")
                 //.Include("~/assets/css/datatables.min.css")
                 .Include("~/assets/css/jquery-ui.custom.min.css")
                 .Include("~/assets/css/chosen.min.css")
                 .Include("~/assets/css/select2.min.css")
                 .Include("~/assets/css/bootstrap-datepicker3.min.css")
                 .Include("~/assets/css/bootstrap-datetimepicker.min.css")
                 .Include("~/assets/css/bootstrap-timepicker.min.css")
                 .Include("~/assets/css/toast/toastr.min.css")
                 .Include("~/assets/css/dataTables.bootstrap.css")
                 .Include("~/assets/css/jstree.style.min.css")
                 .Include("~/assets/css//ace-skins.min.css")
                 .Include("~/assets/css/ace-rtl.min.css")
                 .Include("~/assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
             );

            bundles.Add(new StyleBundle("~/Plugins/iCheck/iCheckCss")
                .Include("~/Plugins/iCheck/all.css")
                )
                ;


           bundles.Add(new StyleBundle("~/assets/css/site")
                .Include("~/assets/css/site.css")
                );
        }
    }
}