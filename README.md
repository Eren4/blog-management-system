# Blog Yönetim Sistemi Bonus Sınav  
Mimari olarak Onion mimarisi seçilmiştir.  

## Core  
Application katmanında CQRS klasörü ve Validasyonlar bulunmaktadır.  

Contract katmanında Repository Interface'leri bulunmaktadır.  

Domain katmanında ise modellerimiz bulunmaktadır.  

## Infrastructure  
Persistence katmanında veritabanı ayarlamaları, context sınıfları ve repository implementasyonu bulunmaktadır.  

## Presentation  
Burada ise entitylerin controllerları ve Program.cs'de backendimizin ayarlamaları bulunmaktadır.  

## Çalıştırma adımları  
Angular'da ilk önce frontend klasörüne gelip, node modüllerini indirmek için npm-install komutunun çalıştırılması gerekmektedir.  

Daha sonra ng serve -o komutu ile frontendimiz çalışır hale getirilebilir.  

Backendimiz https://localhost:7024'da çalışmaktadır, ve sonuna /Post, /Category gibi endpointler eklenerek entitylere erişilebilir.