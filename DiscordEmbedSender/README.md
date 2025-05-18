# Discord Embed Sender

Eine Windows Forms Anwendung zum Senden von Discord Embeds über einen Node.js Bot.

## 🚀 Features

- ✨ Benutzerfreundliche GUI zum Erstellen von Discord Embeds
- 🎯 Senden an Kanäle oder Direkte Nachrichten
- 👥 Nutzersuche für DM-Funktionalität  
- 📋 Dynamische Embed Fields mit Inline-Unterstützung
- 👁️ Live-Vorschau der Embeds
- 🎨 Farbauswahl mit Hex-Codes
- ✅ Validierung und Zeichenzählr
- 📊 Umfangreiche Konfigurationsmöglichkeiten
- 📝 Logging-System
- 🔄 Automatische Fehlerbehandlung

## 📋 Voraussetzungen

### Node.js Bot Server
- Node.js 16.x oder höher
- Discord.js v14
- Express.js
- Ein Discord Bot Token

### Windows Client
- Windows 10/11
- .NET Framework 4.7.2 oder höher
- Visual Studio 2019/2022 (für Entwicklung)

## 🛠️ Installation

### 1. Discord Bot Server einrichten

```bash
# Discord Bot Dependencies installieren
npm install discord.js express

# Den bereitgestellten API-Code zu Ihrem bestehenden Bot hinzufügen
```

### 2. Windows Client erstellen

1. Neues Windows Forms Projekt in Visual Studio erstellen
2. NuGet Pakete installieren:
   ```
   Install-Package Newtonsoft.Json
   ```
3. Alle bereitgestellten .cs Dateien in das Projekt kopieren
4. App.config Datei hinzufügen
5. SVG Icons zu Ressourcen hinzufügen (optional)

### 3. Konfiguration

1. **Bot Server**: 
   - Server-IP und Port in der Node.js Anwendung konfigurieren
   - Discord Bot Token einrichten
   - Firewall-Port 3000 öffnen

2. **Windows Client**:
   - `App.config` editieren und Bot API URL anpassen:
   ```xml
   <add key="BotApiBaseUrl" value="http://ihre-server-ip:3000" />
   ```

## 🎮 Verwendung

### Discord Bot starten
```bash
node your-discord-bot.js
```

### Windows Anwendung verwenden

1. **Anwendung starten**: Ausführbare Datei starten
2. **Ziel auswählen**: 
   - Kanal: Server und Kanal aus Dropdown wählen
   - DM: Nutzer suchen und auswählen
3. **Embed konfigurieren**:
   - Titel, Beschreibung, Farbe, etc. eingeben
   - Fields nach Bedarf hinzufügen
4. **Vorschau**: Optional Embed-Vorschau anzeigen
5. **Senden**: Embed absenden

## 📁 Projektstruktur

```
DiscordEmbedSender/
├── Form1.cs                 # Hauptformular Code
├── Form1.Designer.cs        # UI Designer Code
├── Program.cs               # Einstiegspunkt
├── Models.cs                # Datenmodelle
├── DiscordApiClient.cs      # API Client für Bot
├── EmbedBuilder.cs          # Embed Erstellung
├── PreviewForm.cs           # Vorschau-Fenster
├── AppSettings.cs           # Konfiguration
├── Logger.cs                # Logging System
├── App.config               # Anwendungsconfig
└── Icons/                   # SVG Icons
    ├── app-icon.svg
    ├── send-icon.svg
    ├── preview-icon.svg
    ├── search-user-icon.svg
    ├── add-field-icon.svg
    └── remove-field-icon.svg
```

## ⚙️ Konfiguration

### Wichtige Einstellungen in App.config:

- `BotApiBaseUrl`: URL des Bot Servers
- `ConnectionTimeout`: Timeout für API-Aufrufe
- `DefaultEmbedColor`: Standard Hex-Farbe
- `MaxEmbedFields`: Maximale Anzahl Fields
- `EnableLogging`: Logging aktivieren/deaktivieren

### Discord Embed Limits:

- Titel: 256 Zeichen
- Beschreibung: 4096 Zeichen  
- Fields: Max. 25 Fields
- Field Name: 256 Zeichen
- Field Value: 1024 Zeichen
- Footer: 2048 Zeichen
- Autor: 256 Zeichen
- Gesamt: 6000 Zeichen

## 🐛 Troubleshooting

### Häufige Probleme:

1. **Verbindung fehlgeschlagen**:
   - Bot Server läuft?
   - Firewall-Einstellungen prüfen
   - API URL korrekt in App.config?

2. **Bot antwortet nicht**:
   - Bot Token gültig?
   - Bot hat Berechtigung in Server?
   - Express Server läuft?

3. **Kanäle werden nicht geladen**:
   - Bot ist Member des Servers?
   - Bot hat Leseberechtigung?

### Logs einsehen:

Die Anwendung erstellt automatisch Log-Dateien in:
```
[Anwendungsverzeichnis]/Logs/DiscordEmbedSender_YYYY-MM-DD.log
```

## 🔒 Sicherheitshinweise

1. **API Absicherung**: Implementieren Sie Authentifizierung für die Bot API
2. **Rate Limiting**: Begrenzen Sie API-Anfragen
3. **Firewall**: Beschränken Sie Zugriff auf vertrauenswürdige IPs
4. **HTTPS**: Verwenden Sie HTTPS in Produktionsumgebung
5. **Bot Token**: Niemals Bot Token im Client speichern

## 🤝 Beitragen

1. Repository forken
2. Feature Branch erstellen (`git checkout -b feature/AmazingFeature`)
3. Änderungen committen (`git commit -m 'Add some AmazingFeature'`)
4. Branch pushen (`git push origin feature/AmazingFeature`)
5. Pull Request erstellen

## 📄 Lizenz

Dieses Projekt steht unter der MIT Lizenz - siehe LICENSE Datei für Details.

## 🙏 Danksagungen

- Discord.js Community
- Microsoft für .NET Framework
- Newtonsoft für JSON.NET

## 📞 Support

Bei Fragen oder Problemen:
1. GitHub Issues verwenden
2. Logs mit Fehlermeldung bereitstellen
3. Konfiguration und Umgebung beschreiben

---

**Version**: 1.0.0  
**Aktualisiert**: 2025  
**Autor**: [TheDemonLord333]