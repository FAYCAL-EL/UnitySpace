   M S B A M L   `   `   `  ����E  AUnitySpace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UnitySpace
UnitySpace  5      $    UnitySpace.Show_Meeting_Member   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:UnitySpace     5      $��Poppins)�5      $	��624��5	      $	��800��6     � 	Resources  5      .   (UnitySpace.DateTimeToVisibilityConverter !  DateTimeToVisibilityConverter��%   &	          5   
   6.   5      .��5      � 
�������.+�5   
   �� $��0,0,5,0q�6   .+�5      �� -   5        
������ $��0,0,0,0q�5   E   $
��Left=�6_   ��6.   Z� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��15��6    $��15��6+   ��5      �� 5       �� ImageSource$ /Images/back.png��6)   5      �� 5      
���   �$��70��63   �� 6?   $�  ��6C   �� 6O    � Language$ fr-fr�6S   $	�   ��6d   �� 6q   $
�Back��6u   6�   5      5      �� 5      -   5         ��Name$ meetingTitle��5      $��20(�6/   $
��Bold"�6=   $
��Left=�6O   $��	40,20,0,0q�6j   �� 5       -   5        $ meetingDescription��5       $
��Wrap=�65   $
��Left=�6I   $	��600��6d   $��	40,11,0,0q�6p   �� 5!      $��Meeting Date : ��6   $��14(�6/   $��DemiBold"�6=   $
��Left=�6S   $��	40,10,0,0q�6n   �� 5"      -   5        $ meetingDate��5"      $
��Left=�6-   $��	40,20,0,0q�6H   �� 5#      $��Meeting Place : ��6   $��DemiBold"�60   $��14(�6F   $
��Left=�6T   $��	40,20,0,0q�6o   �� 5$      -   5        $ meetingPlace��5$      $
��Left=�6/   $��	40,20,0,0q�6J   �� 5%      $��Participants : ��6   $��DemiBold"�6/   $��14(�6E   $
��Left=�6S   $��	40,50,0,0q�6n   �� 5'      -   5         ��Name$ participants��5'      $ 
Horizontal=�6/   $
��Left=�6H   $��	40,30,0,0q�6c   $��40��6v   6�   5(      �� 5*   
   $��Center=�6   $	��Top=�62   $	��240��6J   $	��267��6W   $��504,376,0,0q�6c   .+�5,      �� -   5         ��Name$ DownloadButton��5,      ���#3880FF$��50��6B   $��50��6M   $��
-30,60,0,0q�6v   y�6�   �� *MeetingStartingDate+ �� 	Converter# [   �� RelativeSource �� 	 �� AncestorType$	 UserControlL���6)  Z� 
 J� Effect
 5-      3  -System.Windows.Media.Effects.DropShadowEffect  5.         Color$
 Gray��6'      	Direction$	 315Q�64      ShadowDepth$ 2Q�6D      Opacity$	 0.8Q�6T   .��50      �� $��Images/download.png��6   $��20��65   $
��Left=�6@   $��Center=�6[   6x   ��51      �� 52       �� 
TargetType" ��6&   .R�53      � .+�54      ��  ��Name$ border��6%   #��z��65    �� CornerRadius$ 50��6_   �� 55       ��Name$ contentPresenter��6/   $��Center=�6I   $��Center=�6d   56       �� Triggers 57      P� 58       P� Property �@J�IsMouseOver P� Value . . �59   "   ��  �� 
TargetName$ border��6)    �� Property � �� �� Value �	#FF34495E6S   5:      P� 5;       � �� . . �5<   "   �� $ border��6)    � �� �	#FF2C3E506S   5=      5?      5B      �� 5D      -   5        $ DownloadMessaage��5D      $
��Wrap=�62   $�� ��6F   $��
-30,15,0,0q�6N   $	��180��6b   ��5E      �� 5F       �� 
TargetType" ��6   .�5G      ��  � y�$ 	Collapsed=�67    �� Triggers 5H      �� 5I       �� Binding 6*   �� *
Visibility+ �� ElementName$ DownloadButton�� �� Value Visible6e   .a�5J   "   ��  � y�$ Visible=�6?   5K      5M      5O      5S      5U      5W      