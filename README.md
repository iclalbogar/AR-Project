AR Hand Detection & Animal Sounds Project
Bu proje, MediaPipe Unity Plugin kullanarak gerçek zamanlı el takibi yapan ve kullanıcının işaret parmağıyla sanal hayvanlara dokunarak ses çıkarmasını sağlayan bir Artırılmış Gerçeklik (AR) uygulamasıdır.

🚀 Proje Hakkında
Bu çalışma, Çukurova Üniversitesi Bilgisayar Mühendisliği bölümü bitirme/ödev çalışmaları kapsamında geliştirilmiştir. Kullanıcı kameradan elini gösterdiğinde, işaret parmağı ucu (landmark 8) tespit edilir ve bu noktaya fiziksel bir collider (küre) atanır. Kullanıcı bu küre aracılığıyla sahnede bulunan hayvan modellerine temas ettiğinde ilgili hayvanın sesi tetiklenir.

🛠️ Teknik Özellikler
El Takibi: MediaPipe Hand Landmarker API kullanılarak 21 el eklem noktası anlık olarak takip edilir.

Dinamik Etkileşim: İşaret parmağı koordinatları, MobileHandLinker scripti aracılığıyla 3D uzaydaki bir objeye (IndexFingerCollider) aktarılır.

Ses Sistemi: Hayvan modelleri üzerine yerleştirilen trigger sistemleri, parmak objesiyle temas anında ses üretimini sağlar.

Görüntü İşleme: cam2 ve Annotatable Screen üzerinden kamera görüntüsü işlenerek landmarklar ekrana çizdirilir.

👥 Proje Ekibi ve Danışmanlar
Geliştirici: Esra İclal Boğar - @esraiclal

Proje Danışmanı / Hocası: @HocaKullaniciAdi (Lütfen hocanızın GitHub kullanıcı adını buraya yazın)

📦 Kurulum ve Çalıştırma
Bu repository'yi klonlayın.

Unity 2022.3.x sürümü ile projeyi açın.

Packages klasöründen MediaPipe Unity Plugin'in kurulu olduğundan emin olun.

Solution objesindeki HandLandmarkerRunnerConfig dosyasına hand_landmarker.task dosyasını bağlayın.

Play butonuna basarak kameranızı başlatın.