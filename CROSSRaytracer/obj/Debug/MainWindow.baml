   M S B A M L   `   `   `  ����I  ECROSSRaytracer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CROSSRaytracerCROSSRaytracer  5   	       CROSSRaytracer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CROSSRaytracer     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)    � 
ResizeMode$ NoResize=�65   .��5	      � .+�5
   
   �� -   5         ��Name$ 
canvasView��5
      $	��371��6%   $	��Top=�62   $
��Left=�6J   $	��594��6e   
���   �6q   �� 5   
   $
��Left=�6   $	��185��60   $��
473,10,0,0q�6=   $	��Top=�6Q   $	��100��6i   .+�5      �� -   5         ��Name$ renderSphere��5      $��Render sphere��6+   $	��Top=�6C   $
��Left=�6[   $	��100��6v   $
��0,10q�6�   $��30��6�   �� 5      -   5        $ renderTriangle��5      $��Render triangle��6-   $	��Top=�6G   $
��Left=�6_   $	��100��6z   $
��0,10q�6�   $��30��6�   �� 5      -   5        $ renderPlane��5      $��Render plane��6*   $	��Top=�6A   $
��Left=�6Y   $	��100��6t   $
��0,10q�6�   $��30��6�   5      � 5   
   -   5         �Name$ 
loadingBar��5       � IsIndeterminate . $	��594��6A   $��10��6M   $��Bottom=�6Y   5      5      