   M S B A M L   `   `   `  ���� G  CQuizMyNumber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuizMyNumberQuizMyNumber      QuizMyNumber.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:QuizMyNumber       � 
ResizeMode$  NoResize=� � Title$ 	My number��$	��450��$	��740�� � Icon$ Pictures/smile.ico��.��� -    �Name$ MainGrid��
����� �.+��� -    ��Name$ TextBlockTargetNumber1��
����  �
�������$��Center=�$��-100,68,0,0q� �� TextAlignment$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��46��$��40���� -   $ TextBlockTargetNumber2��
����  �
�������$��Center=�$��0,68,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��46��$��40���� -   $ TextBlockTargetNumber3��
����  �
�������$��Center=�$��
100,68,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��46��$��40���� -   $ TextBlockRandomNumber1��
����  �
�������$
��Left=�$��
38,160,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��45��$��40���� -   $ TextBlockRandomNumber2��
����  �
�������$
��Left=�$��
97,160,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��45��$��40���� -   $ TextBlockRandomNumber3��
����  �
�������$
��Left=�$��152,160,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��45��$��40���� -   $ TextBlockRandomNumber4��
����  �
�������$
��Left=�$��206,160,0,0q�$ Center=�$
��Wrap=�$��0��$	��Top=�$��30(�$
��Bold"�$��45��$��40���� -	   $ TextBlockRandomNumber10��
����  �
�������$
��Left=�$��497,160,0,0q�$ Center=�$
��Wrap=�$��00��$	��Top=�$��30(�$
��Bold"�$��45��$��75���� -
   $ TextBlockRandomNumber100��
����  �
�������$
��Left=�$��622,160,0,0q�$ Center=�$
��Wrap=�$	��000��$	��Top=�$��30(�$
��Bold"�$��45��$��75���� -    ��Name$ 
ButtonPlus��$��+��$��	-1,-4,0,4q�
�������
���   �$��30(�$
��Bold"�$
��Left=�$��
38,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -   $ ButtonMinus��$��-��$��	-1,-4,0,4q�
�������
���   �$��30(�$
��Bold"�$
��Left=�$��
97,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -   $ ButtonDivide��$��/��$��	-1,-4,0,4q�
�������
���   �$��30(�$
��Bold"�$
��Left=�$��152,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -   $ ButtonMultiple��$��*��$��0,2,0,0q�
�������
���   �$��30(�$
��Bold"�$
��Left=�$��206,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -   $ ButtonOpenBracket��$��	-1,-4,0,4q�$��(��
�������
���   �$��30(�$
��Bold"�$
��Left=�$��263,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -   $ ButtonClosedBracket��$��	-1,-4,0,4q�$��)��
�������
���   �$��30(�$
��Bold"�$
��Left=�$��322,253,0,0q�$	��Top=�$��Center=�$��Center=�$��40��$��40���� -    ��Name$ TextBoxInput�� �� 
IsReadOnly . 	 �� TextAlignment$	 Center=�$
��Left=�$��45��$��
38,334,0,0q�
 �� TextWrapping$

 Wrap=�$��30(�$�� ��$	��Top=�$	��509���� -   $ ButtonNewGame��$��New game��
���/���$
��Bold"�$
��Left=�$��
622,28,0,0q�$	��Top=�$��75���� -   $ TextBlockTime��$
��Left=�$��	38,15,0,0q�$
��Wrap=�$
��Bold"�$��25(�$��00:00��$	��Top=�$��33��$��66���� -   $ TextBlockResult��
�������$��30(�$
��Bold"�$
��Left=�$��577,334,0,0q�$
��Wrap=�$�� ��$ Center=�$	��Top=�$��45��$	��120���� -   $ ButtonDelete��$��	BackSpace��$��0q�
���  ��
���   �$��20(�$
��Bold"�$
��Left=�$��397,253,0,0q�$	��Top=�$��Center=�$��Center=�$	��105��$��40���� -   $ ButtonEnter��$��Enter��$��0q�
���/���
���   �$��20(�$
��Bold"�$
��Left=�$��608,255,0,0q�$	��Top=�$��Center=�$��Center=�$��89��$��40���� $��=��$
��Left=�$��5,0,0,0q�$��547,334,0,0q�$	��Top=�$	��Top=�$��30(�$
��Bold"�$��30��$��45�� J� RenderTransformOrigin$ 0.533,0.356&��� -    ��Name$ 
MainBorder��
����  � K� ZIndex$ -1��$��10q�$
��Left=�$	��411��$��0,0,0,0q�$	��Top=�$	��724��� -   $ 
GridRecord��
����  �$y�Hidden=�$ 1��.+��� -   $ ButtonClose��$��Close��$��Center=�$��5,5,5,5q�$��Bottom=�$��76��&   System.Windows.Controls.DataGrid  -     Name$ DataGridRecord��$��5,5,5,5q�   HeadersVisibility$ Column=�   
IsReadOnly . $��22(�$
��Bold"�   AutoGenerateColumns .   �� AlternationCount$ 2��   AlternatingRowBackground
 �����$��Stretch=�$	��381��$��10,10,10,30q�$��Stretch=�$	��714������ *NewlistRecord+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$  ��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Number+  $
 Name��$ *  �� *Name+  $
 Time��$ *  �� *Time+�� -   $��
LabelCover��$�� ��$y�Hidden=�$
��Left=�$��
38,160,0,0q�$	��Top=�$��45��$	��659��