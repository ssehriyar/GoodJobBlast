# GoodJobBlast
 
Projeyi Unity 2021.3.3f1 versiyonunda geliştiridim

Proje sahnesi Scene dosyasında MainScene içerisinde bulunuyor

<br />Proje içerisinde Gridi oluşturmak için
	<br />GameManager içerisinde Board scripti üzerinden Gridin boyutları ayarlanabilir
	<br />Generate butonu ile oluşturup Clear ile temizlenir
	<br />Oluşan Grid TileParent ve ItemParent içerisinde oluşacaktır
	<br />TileParent içerisindeki objelerin Tile scripti üzerinden ItemType seçilebilir
	<br />Appyly butonu ile Tile üzerindeki Item değiştirilebilir.

Oyunun kurallarını belirlemek için
	<br />Data dosyasında bulunan Sprites scriptable objesi içerisinde
	<br />(A) First Icon Number sayısı ilk ikonu
	<br />(B) Second Icon Number sayısı ikinci ikonu
	<br />(C) Third Icon Number sayısı üçüncü ikonu
	<br />(K) Number Of Colors sayısı kaç renk çeşidi olacağını belirler
	<br />Spritelar Cubes listesi içerisinde bulunuyor
	<br />Belirlenen Number Of Cubes sayısı kadar Cubes listesi kullanılır
	<br />Örneğin Number Of Cubes 3 olsun Cubes içerisinde ilk 3 eleman yani ilk 3 renk kullanılacaktır
	<br />Kullanılmak istenmeyen renkler listenin sonuna taşınmalı, sahne üzerinde bu renkler atanmamalı