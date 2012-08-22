(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,WebSharper,Html,Default,List,T,kendo,alert,Operators,Website,ChartingSamples;
 Runtime.Define(Global,{
  Website:{
   ChartingSamples:{
    Chart:function(chartType,stack)
    {
     var x,f,f1;
     x=Default.Div(Runtime.New(T,{
      $:0
     }));
     f=(f1=function(el)
     {
      var x1,returnVal,returnVal1,returnVal2,returnVal3,returnVal4,returnVal5,returnVal6,returnVal7,returnVal8,returnVal9,returnVala,f2;
      x1=new kendo.ui.Chart(el.Body,(returnVal=[{}],(null,returnVal[0].theme="default",returnVal[0].title=(returnVal1=[{}],(null,returnVal1[0].text="Internet Users",returnVal1[0])),returnVal[0].legend=(returnVal2=[{}],(null,returnVal2[0].position="bottom",returnVal2[0])),returnVal[0].chartArea=(returnVal3=[{}],(null,returnVal3[0].background="",returnVal3[0])),returnVal[0].seriesDefaults=(returnVal4=[{}],(null,returnVal4[0].type=chartType,returnVal4[0].stack=stack,returnVal4[0])),returnVal[0].series=[(returnVal5=[{}],(null,returnVal5[0].name="World",returnVal5[0].data=[15.7,16.7,20,23.5,26.6],returnVal5[0])),(returnVal6=[{}],(null,returnVal6[0].name="United States",returnVal6[0].data=[67.96,68.93,75,74,78],returnVal6[0]))],returnVal[0].categoryAxis=(returnVal7=[{}],(null,returnVal7[0].categories=["2005","2006","2007","2008","2009"],returnVal7[0])),returnVal[0].valueAxis=(returnVal8=[{}],(null,returnVal8[0].labels=(returnVal9=[{}],(null,returnVal9[0].format="{0}%",returnVal9[0])),returnVal8[0])),returnVal[0].tooltip=(returnVala=[{}],(null,returnVala[0].visible=true,returnVala[0].format="{0}%",returnVala[0])),returnVal[0].seriesClick=function(args)
      {
       var msg;
       msg=args.category+" : "+Global.String(args.value);
       return alert(msg);
      },returnVal[0])));
      f2=function(value)
      {
       value;
      };
      return f2(x1);
     },function(w)
     {
      return Operators.OnAfterRender(f1,w);
     });
     f(x);
     return x;
    }
   },
   KendoUIChartingViewer:Runtime.Class({
    get_Body:function()
    {
     return Default.Div(List.ofArray([ChartingSamples.Chart("column",false)]));
    }
   })
  }
 });
 Runtime.OnInit(function()
 {
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  Default=Runtime.Safe(Html.Default);
  List=Runtime.Safe(WebSharper.List);
  T=Runtime.Safe(List.T);
  kendo=Runtime.Safe(Global.kendo);
  alert=Runtime.Safe(Global.alert);
  Operators=Runtime.Safe(Html.Operators);
  Website=Runtime.Safe(Global.Website);
  return ChartingSamples=Runtime.Safe(Website.ChartingSamples);
 });
 Runtime.OnLoad(function()
 {
 });
}());
