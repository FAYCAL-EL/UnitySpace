   M S B A M L   `   `   `  ����E  AUnitySpace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UnitySpace
UnitySpace  5      "    UnitySpace.Show_Meeting_Chef   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:UnitySpace     5      $��Poppins)�5	      $	��624��5
      $	��800��6     � 	Resources  5      .   (UnitySpace.DateTimeToVisibilityConverter !  DateTimeToVisibilityConverter��%   &	          5   
   6.   5      .��5      � 
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
��Left=�6I   $	��620��6d   $��	40,11,0,0q�6p   �� 5!      $��Meeting Date : ��6   $��14(�6/   $��DemiBold"�6=   $
��Left=�6S   $��	40,20,0,0q�6n   �� 5"      -   5        $ meetingDate��5"      $
��Left=�6-   $��	40,10,0,0q�6H   �� 5#      $��Meeting Place : ��6   $��DemiBold"�60   $��14(�6F   $
��Left=�6T   $��	40,20,0,0q�6o   �� 5$      -   5        $ meetingPlace��5$      $
��Left=�6/   $��	40,10,0,0q�6J   �� 5%      $��Participants : ��6   $��DemiBold"�6/   $��14(�6E   $
��Left=�6S   $��	40,20,0,0q�6n   �� 5'      -   5         ��Name$ participants��5'      $ 
Horizontal=�6/   $
��Left=�6H   $��	40,30,0,0q�6c   $��40��6v   6�   �� 5(      $	��240��6   $	��267��6&   $��Right=�62   $��50,-200q�6N   .+�5+      �� -   5         ��Name$ AttachButton��5+      ���#3880FF$	��197��6`   $��37��6+  y�6l   �� *MeetingStartingDate+ �� 	Converter# [   �� RelativeSource �� 	 �� AncestorType"	 >���6  Z� .��5,      �� $ 
Horizontal=�6!   .+�5-      �� $ ��Images/cloud-computing.png��6    $��0 0 10 0q�6D   $��15��6V   �� 5.      �� 6&   $�Upload PDF Report��6*   6F   5/      50      �� 51      -   5        $ AttachmentMessage��51      $
��Wrap=�67   $�� ��6K   $��	0, 15,0,0q�6S   $	��220��6f   $��Center=�6r   ��52      �� 53      
 �� 
TargetType"
 ��6    .�54      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 55      �� 56   "    �� Binding 6.   �� *
Visibility+ �� ElementName$ AttachButton�� �� Value Visible6g   .a�57   &   ��  � y�$ Visible=�6C   58   #   5:      5<      �� 5?      -	   5        $ DownloadButton��5?      ���#3880FF$��50��6F   $��50��6Q   $��
-30,30,0,0q�6z   y�6�   �� *MeetingStartingDate+# [   �� "	 >���66  Z�  J� Effect 5@      3  -System.Windows.Media.Effects.DropShadowEffect  5A         Color$
 Gray��6+      	Direction$	 315Q�68      ShadowDepth$ 2Q�6H      Opacity$	 0.8Q�6X   ��5C      �� 5D       �� 
TargetType" ��6*   .R�5E      � .+�5F   "   ��  ��Name$ border��6)   #��z��69    �� CornerRadius$ 50��6c   �� 5G   "    ��Name$ contentPresenter��63   $��Center=�6M   $��Center=�6h   5H       �� Triggers 5I      P� 5J   "    P� Property �@J�IsMouseOver P� Value . . �5K   &   ��  �� 
TargetName$ border��6-    � �� �	#FF34495E6W   5L   #   P� 5M   "    � �� . . �5N   &   �� $ border��6-    � �� �	#FF2C3E506W   5O   #   5Q      .��5T      �� $��Images/download.png��6   $��15��69   $
��Left=�6D   $��Center=�6_   5V      �� 5X      -
   5        $ DownloadMessaage��5X      $
��Wrap=�66   $�� ��6J   $��	0, 15,0,0q�6R   $	��207��6e   $��20��6q   5\      5^      5`      5b      