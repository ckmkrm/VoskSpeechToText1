# 🎤 Vosk Speech to Text (C# Windows Forms)

Bu proje, [Vosk](https://alphacephei.com/vosk/) kütüphanesini kullanarak **Türkçe konuşmayı metne dönüştürür**.  
Uygulama, **NAudio** ile mikrofon girişini dinler ve **Vosk** modeliyle gerçek zamanlı konuşma tanıma yapar.



## 🧠 Özellikler
- 🎙️ Gerçek zamanlı mikrofon kaydı
- 🗣️ Türkçe konuşmayı anlık olarak metne çevirme
- 🪶 Hafif ve hızlı `vosk-model-small-tr-0.3` modelini kullanır
- 🪟 Modern C# (.NET 8) Windows Forms arayüzü
- 🧹 Stabil, tekrar etmeyen metin çıktısı

---

## 🧰 Gerekli NuGet Paketleri
Projeyi açmadan önce aşağıdaki NuGet paketlerini yükle:

| Paket | Açıklama |

| `Vosk` | Ses tanıma motoru |
| `NAudio` | Mikrofon verisini almak için |
| `Newtonsoft.Json` | JSON sonuçlarını ayrıştırmak için |

**Visual Studio'da yüklemek için:**  
`Tools → NuGet Package Manager → Manage NuGet Packages → Browse`



## 🧩 Gerekli Model Dosyası
Model dosyası GitHub’a yüklenmedi çünkü boyutu çok büyük.  
Aşağıdaki adımları izleyerek indirip doğru konuma koymalısın 👇

1. Modeli indir:  
   🔗 [vosk-model-small-tr-0.3](https://alphacephei.com/vosk/models)
2. Zip dosyasını çıkart:
   C:\Users\lenovo-pc\Downloads\vosk-model-small-tr-0.3\vosk-model-small-tr-0.3


## 🚀 Nasıl Çalıştırılır

1. Projeyi Visual Studio 2022’de aç

2. Platform target’ı x64 yap

3. NuGet paketlerini yükle

4. vosk-model-small-tr-0.3 klasörünü doğru yere koy

5. Uygulamayı F5 ile başlat

6. “Start” tuşuna bas → konuş → anında metin oluşsun 🎧
 
