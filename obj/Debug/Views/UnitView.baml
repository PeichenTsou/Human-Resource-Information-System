   M S B A M L   `   `   `  ????C  ?HRIS_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HRIS_WPF.ViewsHRIS_WPF.Views  5      ;"clr-namespace:HRIS_WPF.ControllersHRIS_WPF.Controllers  5      3clr-namespace:HRIS_WPF.EntitesHRIS_WPF.Entites  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          HRIS_WPF.Views.UnitView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:HRIS_WPF.Views     5      :controllers"clr-namespace:HRIS_WPF.Controllers     5      3entitiesclr-namespace:HRIS_WPF.Entites     5      9system&clr-namespace:System;assembly=mscorlib     5	        ? 	Resources  5      -   'HRIS_WPF.Controllers.UnitViewController   unitViewController  unitList S? ObjectInstance S? 
MethodName S? MethodParameters ?? Member  unitTemplate ?? DataType   HRIS_WPF.Entites.Unit ?? Orientation ?? Path??%u  &	        &	      7   &	 ?       5   
   6)   S? 5   
   8   $ getFilteredUnitsList??5       5      ?? 5      $ system:String.Empty??6   5      ?? 5   
   "  6-   .R?5      ?? $ 
Horizontal=?6   .+?5      ?? ??6   ?? $ unitCode??? 5      $?? ??6   ?? 5      ??6   ?? $ 	unitTitle?5      5       5!      .??5#      ?  ? ColumnDefinitions 5$   
   ?? 5%      $??3* ?6   6,   ?? 5&      $??5* ?6   6,   	 ? RowDefinitions	 5(   
   ?? 5)      $??40 ?6   6*   ?? 5*      $??40 ?6   6*   ?? 5+      $??* ?6   6)   .+?5.   
   ?? $??	Unit List??6   $
??5, 7q?6$   $??0??62   $??0??6B   $
??Bold"?6O   $??14(?6a   ?? 5/   
   $??Unit Detials??6   $
??5, 7q?6'   $??1??65   $??0??6E   $
??Bold"?6R   $??14(?6d   ?? 50   
   -   5        $??UnitTitleOfUnitDetail??50      $??90, 7, 5, 7q?6-   $??1??6B   $??0??6R   $??14(?6_   ?? 53   
   $??Search Unit :??6   $
??5, 7q?6)   $??0??67   $??1??6G   ?? 54   
   -   5        $??	seachText??54      $
??Left=?6#   $??97??6>   $??90, 11, 0 ,9q?6I   $??0??6_   $??1??6o   .??6?   .??55   O   .??56      ?? 
 ?? Source#
 [ 6   $ MethodParameters[0]?57       ?? BindsDirectlyToSource .  ?? UpdateSourceTrigger$ PropertyChanged=?59      5:      ?? 5=   
   $??Filter By Campus:??6   $
??Left=?6,   $	??126??6H   $??1??6T   $??1??6d   $
??5, 7q?6q   ?? 5>   
   -   5         ??Name$ filterCampus??5>      $
??Left=?6)   $??97??6D   $??1??6O   $??1??6_   $??115, 8, 0 ,8q?6l   $??22??5?        ?? SelectedIndex$ 0??6,   .@?5@      ?? .??6   
All Campus6'   ?? 5A      .??6   Hobart6#   ?? 5B      .??6   
Launceston6'   5C      ?? 5E   
   -   5        $??UnitListView??5E      $??0??6(   $??2??68   $??3q?6E   #??[ 5G      ??5F      ?? #
 [ 5G   B   ?? 5I   
   -   5         ??Name$ UnitDetailList??5I      $??1??6+   $??2??6;   $??3q?6H    ?? View 5J      ?? 5K      .P?5L      ?? $	??Day??6%    ?? DisplayMemberBinding 62   ?? *	weekDay+?? 5M      $
??Time??6%    63   ?? *
timePeriod+?? 5N      $
??Type??6%    63   ?? *	ClassType+?? 5O      $
??Room??6%    63   ?? *roomLocation+?? 5P      $??Campus??6%    65   ?? *campus+?? 5R      $??
Staff Name??6%    ?? CellTemplate 5T      ?? 5U      .R?5V   "   ?? $??urlToContent??6-   $	??100??6A   $
??Auto??6P   ?? 5W   &    ?Name$ hlkURL??6W   -   5        ??5W   0   ?? $ 	staffName?.?6?   .?5X   *   ?? ??64   ?? $ 	staffName?5Y   '   5Z   #   5[      5]      5^      5`      5a      5b      