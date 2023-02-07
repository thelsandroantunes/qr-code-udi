// Gerar QR Code à partir de número UDI

using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;


string udi = "1010003526877 17072022 10032125 30750496";

QRCodeGenerator qrGen = new QRCodeGenerator();
QRCodeData qrData = qrGen.CreateQrCode(udi, QRCodeGenerator.ECCLevel.Q);
QRCode qrCode = new QRCode(qrData);

string folderPath = "img-qrcode-test";
string fileName = "qrcode-udi.png";
string filePath = Path.Combine(folderPath, fileName);
int i = 0;

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

while (File.Exists(filePath))
{
    i++;
    fileName = "qrcode-udi-" + i + ".png";
    filePath = Path.Combine(folderPath, fileName);
}

using (Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20))
{
    qrCodeAsBitmap.Save(filePath, ImageFormat.Png);
}



