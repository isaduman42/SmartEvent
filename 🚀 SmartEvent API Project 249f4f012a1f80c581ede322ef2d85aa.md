# 🚀 SmartEvent API Project

### 🏗️ Project Structure

```
/SmartEvent.API
  /Controllers
    UserController.cs
  /Models
    User.cs
  /Migrations
  /Program.cs

```

### 🌐 API Endpoints

Base Url:https://smartevent.onrender.com

Swagger: https://smartevent.onrender.com/swagger/index.html

Firebase Token Doğrulama

| Alan | Değer |
| --- | --- |
| Endpoint | POST /api/auth/verify-token |
| Content-Type | application/json |
| Request Body | Firebase ID Token (string) – "eyJhbGciOiJSUzI1NiIsImtpZCI6Ij..." |
| Token Alma (Flutter) | FirebaseAuth.instance.currentUser?.getIdToken() |
| Başarılı Response | { "uid": "firebase-uid" } |
| Hatalı Response | { "error": "Firebase ID token has expired" } |

Event Endpoints

| HTTP Method | Endpoint | Açıklama | Body (JSON) |
| --- | --- | --- | --- |
| POST | /api/event | Yeni etkinlik oluştur | { "title": "Konser", "description": "Açık hava konseri", "location": "Konya", "date": "2025-09-01T20:00:00", "capacity": 500 } |
| GET | /api/event | Tüm etkinlikleri getir | — |
| GET | /api/event/{id} | Belirli etkinliği getir | — |
| PUT | /api/event/{id} | Etkinliği güncelle | { "title": "Konser", "description": "Açık hava konseri", "location": "Konya", "date": "2025-09-01T20:00:00", "capacity": 500 } |
| DELETE | /api/event/{id} | Etkinliği sil | — |

Event Response

| Alan | Tür | Açıklama |
| --- | --- | --- |
| id | int | Etkinliğin benzersiz ID’si |
| title | string | Etkinlik başlığı |
| description | string | Etkinlik açıklaması |
| location | string | Mekan bilgisi |
| date | string | Etkinlik tarihi ve saati (ISO) |
| capacity | int | Katılımcı kapasitesi |
| createdAt | string | Oluşturulma tarihi (opsiyonel) |
| updatedAt | string | Son güncelleme tarihi (opsiyonel) |

Ticket Endpoints

| HTTP Method | Endpoint | Açıklama | Body (JSON) |
| --- | --- | --- | --- |
| POST | /api/ticket | Yeni bilet oluştur | { "eventId": 1, "userId": "abc123", "createdAt": "2025-08-12T14:00:00", "isCheckedIn": false } |
| GET | /api/ticket | Tüm biletleri getir | — |
| GET | /api/ticket/{id} | Belirli bileti getir | — |
| PUT | /api/ticket/{id} | Bileti güncelle | { "eventId": 1, "userId": "abc123", "createdAt": "2025-08-12T14:00:00", "isCheckedIn": true } |
| DELETE | /api/ticket/{id} | Bileti sil | — |

Ticket Response

| Alan | Tür | Açıklama |
| --- | --- | --- |
| id | int | Biletin benzersiz ID’si |
| eventId | int | İlgili etkinliğin ID’si |
| userId | string | Bileti alan kullanıcının Firebase UID’si |
| createdAt | string | Biletin oluşturulma tarihi (ISO) |
| isCheckedIn | boolean | Kullanıcı etkinliğe giriş yaptı mı |

User Response

| Alan | Tür | Açıklama |
| --- | --- | --- |
| id | string | Firebase UID |
| name | string | Kullanıcının adı |
| email | string | E-posta adresi |
| createdAt | string | Hesap oluşturulma tarihi (ISO) |
| role | string | Kullanıcı rolü (örneğin: "user") |

User Endpoints

| Method | Endpoint | Açıklama | Gönderilen veri |
| --- | --- | --- | --- |
| POST | /api/user | Yeni kullanıcı oluştur | {  “name”: “ “ ,  “email” :  “  “ ,  “role” :  “ “ } |
| GET | /api/user | Tüm kullanıcıları getir | - |
| GET | /api/user/{id} | Belirli kullanıcıyı getir | - |
| PUT | /api/user/{id} | Kullanıcıyı güncelle | {  “name”: “ “ ,  “email” :  “  “ ,  “role” :  “ “ } |
| DELETE | /api/user/{id} | Kullanıcıyı sil | - |

---
