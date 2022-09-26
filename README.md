# GoodJobBlast
 
Projeyi Unity 2021.3.3f1 versiyonunda geliştiridim

Proje sahnesi Scene dosyasında MainScene içerisinde bulunuyor

Proje içerisinde Gridi oluşturmak için  
	GameManager içerisinde Board scripti üzerinden Gridin boyutları ayarlanabilir  
	Generate butonu ile oluşturup Clear ile temizlenir  
	Oluşan Grid TileParent ve ItemParent içerisinde oluşacaktır  
	TileParent içerisindeki objelerin Tile scripti üzerinden ItemType seçilebilir  
	Appyly butonu ile Tile üzerindeki Item değiştirilebilir  

Oyunun kurallarını belirlemek için  
	Data dosyasında bulunan Sprites scriptable objesi içerisinde  
	(A) First Icon Number sayısı ilk ikonu  
	(B) Second Icon Number sayısı ikinci ikonu  
	(C) Third Icon Number sayısı üçüncü ikonu  
	(K) Number Of Colors sayısı kaç renk çeşidi olacağını belirler  
	Spritelar Cubes listesi içerisinde bulunuyor  
	Belirlenen Number Of Cubes sayısı kadar Cubes listesi kullanılır  
	Örneğin Number Of Cubes 3 olsun Cubes içerisinde ilk 3 eleman yani ilk 3 renk kullanılacaktır  
	Kullanılmak istenmeyen renkler listenin sonuna taşınmalı, sahne üzerinde bu renkler atanmamalı  