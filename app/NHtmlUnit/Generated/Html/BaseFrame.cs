// Generated class v4, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Html
{
   public partial class BaseFrame : NHtmlUnit.Html.HtmlElement, NHtmlUnit.W3C.Dom.INode, NHtmlUnit.W3C.Dom.IElement
   {
      static BaseFrame()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.html.BaseFrame o) =>
            new BaseFrame(o));
      }

      public BaseFrame(com.gargoylesoftware.htmlunit.html.BaseFrame wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.html.BaseFrame WObj
      {
         get { return (com.gargoylesoftware.htmlunit.html.BaseFrame)WrappedObject; }
      }


      public System.String SrcAttribute
      {
         get
         {
            return WObj.getSrcAttribute();
         }
         set
         {
            WObj.setSrcAttribute(value);
         }

      }

      public NHtmlUnit.IPage EnclosedPage
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.IPage>(
               WObj.getEnclosedPage());
         }
      }


      public NHtmlUnit.IWebWindow EnclosedWindow
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.IWebWindow>(
               WObj.getEnclosedWindow());
         }
      }


      public System.String LongDescAttribute
      {
         get
         {
            return WObj.getLongDescAttribute();
         }
      }

      public System.String NameAttribute
      {
         get
         {
            return WObj.getNameAttribute();
         }
         set
         {
            WObj.setNameAttribute(value);
         }

      }

      public System.String FrameBorderAttribute
      {
         get
         {
            return WObj.getFrameBorderAttribute();
         }
      }

      public System.String MarginWidthAttribute
      {
         get
         {
            return WObj.getMarginWidthAttribute();
         }
      }

      public System.String MarginHeightAttribute
      {
         get
         {
            return WObj.getMarginHeightAttribute();
         }
      }

      public System.String NoResizeAttribute
      {
         get
         {
            return WObj.getNoResizeAttribute();
         }
      }

      public System.String ScrollingAttribute
      {
         get
         {
            return WObj.getScrollingAttribute();
         }
      }

      public System.String OnLoadAttribute
      {
         get
         {
            return WObj.getOnLoadAttribute();
         }
      }
   }


}
