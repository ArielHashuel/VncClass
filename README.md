# VncClass - Classroom Monitoring and Control Software

## 🔐 Security Features
- **End-to-end encrypted screen sharing and messages** using RSA-encrypted AES session keys
- **Hashed local passwords** using SHA-256

## 🖥️ Features
- Grid layout view for live student screens
- Remote mouse/keyboard control
- Expandable message interface per user
- Teacher screen broadcasting
- Input blocking for class attention (User32.dll)


## 🛠️ Build & Package (GitHub Actions)
We use GitHub Actions for automated packaging and artifact uploads.

> **Path:** `.github/workflows/build.yml`

**How to build manually:**
1. Open `VncClass.sln` in Visual Studio 2022+
2. Modify IP address in `ClientForm.cs` if needed
3. Build in **Release** mode
4. Output `.exe` available in `bin/Release/`

## 🔄 Deployment
- **Teacher App**: Admin privileges required
- **Student App**: Must run as administrator for input blocking
- Recommended deployment: internal LAN environment

## 🧪 Testing Notes
- Manual end-to-end tests preferred due to GUI/control interactions
- Future work: mock virtual student clients for automated scenarios

## 🚀 Roadmap Ideas
- Role-based control panel (teacher vs. student mode)
- Auto-discovery of students on local network
