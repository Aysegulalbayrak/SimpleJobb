# -*- coding: utf-8 -*-
#substring
mesaj = "Merhaba Dünya"

print(mesaj[2:5]) #2. indeksten itibaren 5. indekse kadar geririr örn:rha

yeniMesaj = mesaj[2: ] #2. indeksten itibaren her şeyi verir örn:rhaba Dünya
print(yeniMesaj)


yeniMesaj = mesaj[2:5 ] 
print(yeniMesaj)


yeniMesaj = mesaj[ :2 ] #baştan 2. indekse kadar her şeyi verir örn:Me
print(yeniMesaj)

#Len
#len uzunluk bulma fonsiyonudur.
print(len(mesaj))
yeniMesaj2 = mesaj[len(mesaj)-1 : len(mesaj)] #yeniMesaj = mesaj[12:13] ile aynı işlevi görmektedir.
print(yeniMesaj2)

#Lower-Upper
#Upper metodu, karakterleri büyük harfe çevirir.
#Lower metodu, karakterleri büyük harfe çevirir.
print(mesaj.upper())
print(mesaj.lower())


#replace
#Replace metodu karakter güncellemesi için kullanılır. 
print(mesaj.replace("ü","u"))
#Üstteki ifade değişken üzerinde bir değişiklik yapmaz sadece yazdırırken değiştirir. Ama altta yazan ifade değişkeni değiştirir.
mesaj = mesaj.replace("ü","u")
print(mesaj)

#Split ve Strip
#Split metodu, karakter dizisinde belirtilen bir karaktere göre parçalama işlemi yapar. 
#Strip metodu, karakter dizisinin baş ve sondaki boşluk karakterlerini siler.
bilgi = "       Ayşegül Albayrak 18 İstanbul  ".strip()
print(bilgi.split())
bilgi2 = "       Ayşegül;Albayrak;18;İstanbul  ".strip()
print(bilgi2.split(";"))
print("Adı = " + bilgi2.split(";")[0])

#input
Ad = input("Adınız?")
sayi1 = input("Sayı 1?")
sayi2 = input("Sayı 2?")
print( "Sayıların toplamı = " + str (int(sayi1) + int(sayi2)))