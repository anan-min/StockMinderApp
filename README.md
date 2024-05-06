**StockMinder
อนันต์ มิ่งมิตรพัฒนะกุล 1660706688 section: 327D**

โครงงานนี้เป็นส่วนหนึ่งของวิชา CS356 Mobile Application Development 1
ภาคการศึกษาที่ 2 ปีการศึกษา 2566
ภาควิชาวิทยาการคอมพิวเตอร์ คณะเทคโนโลยีสารสนเทศและนวัตกรรม
มหาวิทยาลัยกรุงเทพ

**ชื่อโครงงาน**
StockMinder แอพพลิเคชั่นจัดการสต๊อคสินค้าและรายงานปัญหา

**1 บทนำ**
วัตถุประสงค์ของโครงงาน
เพื่อพัฒนาแอปพลิเคชันสำหรับจัดการสินค้าในสต๊อคและรายงานปัญหาที่อาจเกิดขึ้น
เพื่อฝึกทักษะกระบวนเขียนแอพพลิเคชั่นด้วย .NET MAUI
ขอบเขตของโครงงาน
แอปพลิเคชันการจัดการจัดการสินค้าในสต๊อคและรายงานปัญหาที่อาจเกิดขึ้น โดยแบ่งออกเป็น 3 ฟังก์ชันหลัก 
**1) Authentication **
register ทำการรับข้อมูลของผู้ใช้งาน employee_id, username, password, email, และ department
login ทำการรับ username และ password ตรวจเช็คและอนุญาติให้เข้าสู่ระบบเมื่อข้อมูลยืนยันตัวตนถูกต้อง
**2) Stock Management **
search item ทำการแสดงสินค้าที่ตรงกับข้อมูลใน search bar เป็น collection view 
edit item ทำการแก้ไขข้อมูลสินค้าที่เลือก 
add item ทำการเพิ่มข้อมูลและรูปภาพของสินค้าใหม่
**3) Report Management**
submit report  สร้าง report ที่ประกอบด้วยชื่อและเนื้อหาและทำกการบันทึกเมื่อผู้ใช้สั่งใช้งาน
view reports ทำการแสดงรายงานที่ถูกบันทึกเป็น list view 

**2 การใช้งาน application **
**2.1 main_page** มี icon สำหรับแต่ละ page ในการเปิดหน้าทั้งหมดใน application ( edit product, search product, add product, authenticate, submit report, และ view reports
**2.2 hamburger_menu**  เป็นส่วนนึงของ application ที่ใช้ในการเปิดหน้าต่างๆใน application
**2.3 register** ทำการกรอก  username, password, email, และ department เมื่อทำการ submit ระบบจะทำการสร้างบัญชี
ของผู้ใช้ที่สามารถใช้งานได้
**2.4 login **ทำการกรอก username และ password เพื่อเข้าสู่ระบบ
**2.5 search item** ทำการค้นหา product ที่มี product id ประกอบด้วย
ข้อความใน search bar และแสดงผลเป็น list view
**2.6 edit item ** ทำการเพิ่มลดจำนวนสินค้าที่เลือกในสต็อคด้วย
การกดปุ่มเพิ่มลด
**2.7 add item **ทำการเพิ่มสินค้าใหม่ในสต็อคซึ่งต้องมีข้อมูลดังนี้ product id, product name, current stock level, stock location, และ product description เมื่้อกรอกครบและทำการ submit product สินค้าจะถูกบันทึกไว้ในระบบ
**2.8 submit report ** กรอก report title และ report details และ กด submit report เพื่อที่จะสร้างรายงานเกี่ยวกับสต็อคสินค้า
**2.9 view reports** ทำการแสดง report ทั้งหมดที่ถูกบันทึกไว้เป็น list view
