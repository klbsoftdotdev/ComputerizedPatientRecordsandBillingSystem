using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace bi_CPRBS
{

    class bi_Codes
    {
        public static string username;
        public static string usertype;

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;

        DataTable dt;
        String bic;
        public bi_Codes()
        {
            con = new MySqlConnection("server = 'localhost'; database = 'spph_db07'; username = 'root'; password = ''");
            da = new MySqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable _code1(String bic)
        {
            dt.Clear();
            con.Open();
            cmd = new MySqlCommand(bic, con);
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void _code2(String bic)
        {
            dt.Clear();
            con.Open();
            cmd = new MySqlCommand(bic, con);
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
        }
        //login code
        public DataTable logincode1(String txtbox1)
        {
            bic = "SELECT name as 'fullname', userID,username,password, access  FROM useraccount WHERE username ='" + txtbox1 + "'";
            return _code1(bic);
        }
        //useraccount code
        public DataTable useraccount()
        {
            //bic = "SELECT userid, accountID as 'ACCOUNT_ID', lastname as 'LASTNAME',firstname as 'FIRSTNAME',middlename as 'MIDDLENAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',access as 'ACCESS',status as STATUS FROM useraccount";
            bic = "SELECT userid, accountID as 'ACCOUNT_ID', name as 'USER FULLNAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',access as 'ACCESS',status as STATUS FROM useraccount";
            return _code1(bic);
        }
        public void saveacc(String dgv3, String dgv4, String dgv5, String dgv6, String dgv7, String lbl5)
        {
            bic = "update useraccount set name='"+dgv3+"',username='"+dgv4+"',password='"+dgv5+"',securityquestion='"+dgv6+"',securityanswer='"+dgv7+"',status='Activated' where userid='"+lbl5+"'";
            _code1(bic);
        }
        //public DataTable newaccount()
        //{
        //    bic = "SELECT accountID as 'ACCOUNT_ID',lastname as 'LASTNAME',firstname as 'FIRSTNAME',middlename as 'MIDDLENAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',access as 'ACCESS',status as STATUS FROM useraccount";
        //    return _code1(bic);
        //}
        public void useraccountcode2(String ln, String fn, String mn, String un, String pw, String ut, String sq, String sa)
        {
            bic = "insert into useraccount(lastname,firstname,middlename,username,password,usertype,securityquestion, securityanswer,status)";
            bic += "values('" + ln + "','" + fn + "','" + mn + "','" + un + "','" + pw + "','"+ut+"','" + sq + "','"+sa+"','Activated')";
            _code2(bic);
        }
        //activate user
        public void Activate(String lbl12)
        {
            bic = "update useraccount set status ='Activated' where userid='" + lbl12 + "'";
            _code1(bic);
        }
        //deactivate user
         public void Deactivate(String lbl12)
         {
            bic = "update useraccount set status ='Deactivated' where userid='" + lbl12 + "'";
            _code1(bic);
         }
        //loghistory code
         public DataTable loghistcode()
         {
             bic = "SELECT useraccount.userid, useraccount.name as 'USER FULLNAME',useraccount.username as 'USERNAME',useraccount.password as 'PASSWORD',loginhistory.timelogin as 'TIME LOGIN',  loginhistory.timelogout as 'TIME LOGOUT',useraccount.access as 'ACCESS',useraccount.status as 'STATUS' from loginhistory inner join useraccount  on loginhistory.userid=useraccount.userid";
             return _code1(bic);
         }
        //assignuser code
         public DataTable assignuser()
         {
             bic = "SELECT userid, concat(lastname,' ',firstname,' ',middlename) as 'USER FULLNAME', username as USERNAME, password as PASSWORD, securityquestion as 'SECURITY QUESTION', securityanswer as 'SECURITY ANSWER',access as 'ACCESS',status as STATUS FROM useraccount";
             return _code1(bic);
         }
        //prompt code
         public void prprecords(String lbl3 )
         {
             bic = "update useraccount set access='CPRBS-PR' where userid="+lbl3;
             _code1(bic);
         }
         public void prpbilling(String lbl3)
         {
             bic = "update useraccount set access='CPRBS-BS' where userid=" + lbl3;
             _code1(bic);
         }
        //forgot code
         public DataTable forgotpass(String txtbox1)
         {
             bic = "SELECT * from useraccount where username='"+txtbox1+"'";
             return _code1(bic);
         }
         public void addpass(String txtb2, String txtb1)
         {
             bic = "update useraccount set password='" + txtb2 + "' where username ='"+txtb1+"'";
             _code1(bic);
         }
        //admission code
         public DataTable admission()
         {
             bic = "SELECT Medrecordno as 'Record Number' , concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'Patient Full Name',age as 'Age', sex as 'Gender', PatientAddress as 'Patient Address', room as 'Room' from registration where status='Registered'";
             return _code1(bic);
         }
         public DataTable pxview()
         {
             bic = "SELECT Medrecordno as 'Patient No.', concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'Patient Full Name' from registration where status='Registered'";
             return _code1(bic);
         }
         public void updateremarks()
         {
             bic = "update registration set remarks=''";
             _code1(bic);
         }
         public DataTable viewallpx()
         {
             bic = "SELECT Medrecordno as 'PATIENT NO.' , concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'PATIENT FULL NAME',age as 'AGE', sex as 'GENDER', room as 'ROOM', PatientAddress as 'ADDRESS' from registration";
             return _code1(bic);
         }
         public DataTable searchallpx(String txtb1)
         {
             bic = "SELECT Medrecordno as 'PATIENT NO.' , concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'PATIENT FULL NAME',age as 'AGE', sex as 'GENDER', room as 'ROOM', PatientAddress as 'ADDRESS' from registration where PtLastname like '%"+txtb1+"%' or PtGivenName='%"+txtb1+"%'";
             return _code1(bic);
         }
         public void addpatient( String pln, String pgn, String pmn,String rm, String pa, String ptn, String sex, String cs,String bd,String age,String bp,String nat,String rel,String Occ,String fname,String fadd,String ftelno,String mname,String madd,String mtelno,String mrn)
         {
             bic = "insert into registration(PtLastName,PtGivenName,PtMiddleName,Room,PatientAddress,PtTelno,Sex,CivilStatus,Birthdate,Age,Birthplace,Nationality,Religion,Occupation,FathersName,FathersAddress,FathersTelNo,MothersName,MothersAddress,MothersTelno,Medrecordno,status)";
             bic += "values('"+ pln + "','" + pgn + "','"+pmn+"','" + rm + "','" + pa + "','" + ptn + "','" + sex + "','" + cs + "','" + bd + "','" + age + "','" + bp + "','" + nat + "','" + rel + "','" + Occ + "','"+ fname + "','" + fadd + "','" + ftelno + "','" + mname + "','" + madd + "','" + mtelno +"','"+mrn+"','Registered')";
             _code2(bic);
         }
        //hospital code
         public void addhospital(String hcode,  String hadd, String hc, String hs, String hz, String city, String hn)
         {
             bic = "insert into hospital(hname,haddress,hcountry,hstate,hzip,city,hcode,status)";
             bic += "values('" + hcode + "','" + hadd + "','"+ hc +"','" + hs + "','" + hz + "','" + city + "','" + hn + "','current')";
             _code2(bic);
         }
         public DataTable viewhospital()
         {
             bic = "select hcode as 'Hospital Code', hname as 'Hospital Name', haddress as 'Address' from hospital";
             return _code1(bic);
         }
         public void updatehospital(String txtb13, String rtxtb1, String txtb14, String txtb15, String txtb16,String txtb17, String txtb12)
         {
             bic = "update hospital set hname='" + txtb13 + "',haddress ='" + rtxtb1 + "', hcountry='"+txtb14+"', hstate='"+txtb15+"',hzip='"+txtb16+"',city='"+txtb17+"',hcode='"+txtb12+"' where hcode='"+txtb12+"'";
             _code1(bic);
         }
         public DataTable hospitalcode()
         {
             bic = "SELECT * from hospital";
             return _code1(bic);
         }
         public void hostat()
         {
             bic = "update hospital set status ='not set'";
             _code1(bic);
         }
         public DataTable hname()
         {
             bic = "SELECT hname FROM hospital WHERE status= 'current'";
             return _code1(bic);
         }
        //addroom code
         public void addroom(String rn, String rt, String rc, String rp)
         {
          bic = "insert into room(roomname,roomtype,roomcapacity,roomprice)";
          bic += "values('" + rn + "','" + rt + "','" + rc + "','" + rp + "')";
          _code2(bic);
         }
         public DataTable viewroom()
         {
             bic = "SELECT roomname as 'Room Name', roomtype as 'Room Type', roomcapacity as 'Room Capacity',roomprice as 'Room Price' FROM room order by roomname asc";
             return _code1(bic);
         }
         public void updateroom(String txtb18, String cmb3, String txtb19, String txtb20)
         {
             bic = "update room set roomname ='"+txtb18+"',roomtype='"+cmb3+"',roomcapacity='"+txtb19+"',roomprice='"+txtb20+"' where roomname='"+txtb18+"'";
             _code1(bic);
         }
         public DataTable roomcode(String txtb18)
         {
             bic = "SELECT * FROM room where roomname='"+txtb18+"'";
             return _code1(bic);
         }
        //add physician codes
         public void addphysician(String ls, String ln, String fn, String mn, String dob, String add, String sp )
         {
             bic = "insert into physician(liscenseno,lastname,firstname,middlename,dateofbirth,address,specialty)";
             bic += "values('" + ls + "','" + ln + "','" + fn + "','" + mn + "','"+dob+"','"+add+"','"+sp+"')";
             _code2(bic);
         }
         public DataTable viewphysician()
         {
             bic = "SELECT liscenseno as 'Liscense Number', concat(firstname,' ',middlename,' ',lastname) as 'Physician Full Name', address as 'Address', specialty as 'Specialty' from physician";
             return _code1(bic);
         }
        //admit patient code
         public DataTable searchpx(String txtb1)
         {
             bic = "SELECT Medrecordno, concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'Patient Full Name' from registration where Status ='Registered' and PtLastName like'"+txtb1+"%'";
             return _code1(bic);
         }
         public void addmitpx(String rn, String pn, String age, String gen, String add, String addate, String adtype, String pname, String roomn, String diag, String atime)
         {
             bic = "insert into admit(recordnumber,patientname,age,gender,address,admissiondate,admissiontype,physicianname,roomname,diagnosis,admissiontime,status)";
             bic += "values('" + rn + "','" + pn + "','" + age + "','" + gen + "','" + add + "','" + addate + "','" + adtype + "','"+pname+"','"+roomn+"','"+diag+"','"+atime+"','Admitted')";
             _code2(bic);
         }
         public void updatepx(String txtb2)
         {
             bic = "update registration set status='Admited' where Medrecordno='" + txtb2 + "'";
             _code1(bic);
         }
        //lab code
         public void laboratory(String labd, String labp)
         {
             bic = "insert into laboratory(labdescription, labprice)";
             bic += "values('" + labd + "','"+labp+"')";
             _code2(bic);
         }
         public DataTable viewlab()
         {
             bic = "select labdescription as 'Laboratory Description', labprice as 'Laboratory Price' from laboratory";
             return _code1(bic);
         }
        //insurance code
         public void insurance(String iname, String iamount)
         {
             bic = "insert into insurance(insurancename, insuranceamount)";
             bic += "values('" + iname + "','" + iamount + "')";
             _code2(bic);
         }
         public DataTable viewinsurance()
         {
             bic = "select insurancename as 'Insurance Name', insuranceamount as 'Insurance Amount' from insurance";
             return _code1(bic);
         }
        //patient information code
         public DataTable medrec(String lbl1)
         {
             bic = "SELECT * FROM registration WHERE Medrecordno='" + lbl1 + "'";
             return _code1(bic);
         }
        //update admission
         public DataTable updateadmission()
         {
             bic = "SELECT Medrecordno, concat(PtLastName,' ',PtGivenName,' ',PtMiddleName) as 'Patient Full Name' FROM registration";
             return _code1(bic);
         }
        //consultation codes
         public void consultation(String pnum, String pname, String page, String ppaddress, String pgender, String condate, String contime, String phyname, String diagnosis)
         {
             bic = "insert into consultation(pnum,pname,page,paddress,pgender,condate,contime,physicianname,diagnosis,status)";
             bic += "values('" + pnum + "','" + pname + "','"+page+"','"+ppaddress+"','"+pgender+"','"+condate+"','"+contime+"','"+phyname+"','"+diagnosis+"','outpx')";
             _code2(bic);
         }
         public DataTable consultationview()
         {
             bic = "SELECT Medrecordno, concat(PtGivenName,' ',PtMiddleName,' ',PtLastName) as 'Patient Full Name' from registration where status='Registered'";
             return _code1(bic);
         }
        //patient history codes
         public DataTable viewpxhistory(String txtb1)
         {
             bic = "SELECT pxno as 'Patient No.', pxname as 'Patient Name', date as 'Date', time as 'Time', pxtype as 'Patient Type' FROM patienthistory WHERE pxno='"+txtb1+"'";
             return _code1(bic);
         }
         public void pxhistory(String pxno, String pxname, String date, String time)
         {
             bic = "insert into patienthistory(pxno,pxname,date,time,pxtype)";
             bic += "values('" + pxno + "','" + pxname + "','" + date + "','" + time + "','INpatient')";
             _code2(bic);
         }
         public void pxhistorycon(String pxno, String pxname, String date, String time)
         {
             bic = "insert into patienthistory(pxno,pxname,date,time,pxtype)";
             bic += "values('" + pxno + "','" + pxname + "','" + date + "','" + time + "','OUTpatient')";
             _code2(bic);
         }
         public DataTable searchpxhistory(String dtp1, String txtb2)
         {
             bic = "SELECT pxno as 'Patient No.', pxname as 'Patient Name', date as 'Date', time as 'Time', pxtype as 'Patient Type' FROM patienthistory WHERE date='" + dtp1 + "' and pxno='"+txtb2+"'";
             return _code1(bic);
         }
        //billing code
         public DataTable admitbill()
         {
             bic = "SELECT recordnumber as 'Patient No.', patientname as 'Patient Full Name' from admit where status='Admitted'";
             return _code1(bic);
         }
        //medicine code
         public void medicine(String medname, String medpurpose, String medprice)
         {
             bic = "insert into medicine(medname,medpurpose,medprice)";
             bic += "values('" + medname + "','" + medpurpose + "','" +medprice+"')";
             _code2(bic);
         }
         public DataTable viewmedicine()
         {
             bic = "SELECT medname as 'Medicine Name', medpurpose as 'Porpuse', medprice as 'Price' FROM medicine";
             return _code1(bic);
         }
        //labhistory code
         public DataTable viewlabhistory2(String txtb2, String dtp7, String dtp8)
         {
             bic = "SELECT patientno as 'Patient No.', date as 'Date', time as 'Time', description as 'Description', price as 'Price'  FROM labhistory where patientno='" + txtb2 + "' and date='" + dtp7 + "'and time='" + dtp8 + "' and status=' ' and remarks='inpx'";
             return _code1(bic);
         }
         public DataTable viewlabhistory(String txtb2)
         {
             bic = "SELECT patientno as 'Patient No.', concat(date,'/ ',time) as 'Date && Time', description as 'Description', price as 'Price'  FROM labhistory where patientno='" + txtb2 + "' and status=' ' and remarks='inpx'";
             return _code1(bic);
         }
         public DataTable outpxlabhistory(String txtb2, String dtp7,String dtp8)
         {
             bic = "SELECT patientno as 'Patient No.', date as 'Date', time as 'Time', description as 'Description', price as 'Price'  FROM labhistory where patientno='" + txtb2 + "' and date='"+dtp7+"'and time='"+dtp8+"' and status=' ' and remarks='outpx'";
             return _code1(bic);
         }
        //medhistory code
         public DataTable viewmedhistory(String txtb2)
         {
             bic = "SELECT pantientno as 'Patient No.', medname as 'Medicine Name', medpurpose as 'Medicine Purpose', medprice as 'Price'  FROM medhistory where pantientno='"+txtb2+"' and status=' ' and remarks='inpx'";
             return _code1(bic);
         }
        //phyhistory
         public void phyhistory(String pno, String pn, String amt, String date, String time)
         {
             bic = "insert into phyhistory(patientno,phyname,amount,date,time,status,remarks)";
             bic += "values('" + pno + "','"+pn+"','" + amt + "','" + date + "','"+time+"',' ','inpx')";
             _code2(bic);
         }
         public DataTable viewphyhistory(String txtb2)
         {
             bic = "SELECT patientno as 'Patient No.', concat(date,'/ ',time)as 'Date & Time',phyname as 'Physician Name', amount as 'Amount' FROM phyhistory where patientno='"+txtb2+"' and status =' ' and remarks='inpx'";
             return _code1(bic);
         }
        //view payments code
         public DataTable viewpayments(String lbl6)
         {
             bic = "SELECT pantientno as 'Patient No.',paydescription as 'Payments Description', payamount as 'Payment Amount' from payments where pantientno='"+lbl6+"' and status=' ' and remarks='inpx'";
             return _code1(bic);
         }
        //consltation view
         public DataTable viewconsult()
         {
             bic = "SELECT pnum as 'Patient No.', pname as 'Patient Name' FROM consultation WHERE status='outpx'";
             return _code1(bic);
         }
        //outpx medview
         public DataTable outpxmedview(String txtb2)
         {
             bic = "SELECT pantientno as 'Patient No.', medname as 'Medicine Name', medpurpose as 'Medicine Purpose', medprice as 'Price'  FROM medhistory where pantientno='" + txtb2 + "' and status=' ' and remarks='outpx'";
             return _code1(bic);
         }
        //outpx labhistory
         public DataTable outlabhistoryview(String txtb2)
         {
             bic = "SELECT patientno as 'Patient No.', concat(date,'/ ',time) as 'Date && Time', description as 'Description', price as 'Price'  FROM labhistory where patientno='" + txtb2 + "' and status=' ' and remarks ='outpx'";
             return _code1(bic);
         }
        //outpx phyhistory
         public void outphyhistory(String pno, String pn, String amt, String date, String time)
         {
             bic = "insert into phyhistory(patientno,phyname,amount,date,time,status,remarks)";
             bic += "values('" + pno + "','" + pn + "','" + amt + "','" + date + "','" + time + "',' ','outpx')";
             _code2(bic);
         }
        //outpx physhistoryview
         public DataTable outpxviewphy(String txtb2)
         {
             bic = "SELECT patientno as 'Patient No.', concat(date,'/ ',time) as 'Date & Time',phyname as 'Physician Name', amount as 'Amount' FROM phyhistory where patientno='" + txtb2 + "' and status =' ' and remarks='outpx'";
             return _code1(bic);
         }
         public DataTable outpxpayments(String lbl6, String lbl9)
         {
             bic = "SELECT pantientno as 'Patient No.',paydescription as 'Payments Description', payamount as 'Payment Amount' from payments where pantientno='" + lbl6 + "' and status=' ' and remarks='outpx'";
             return _code1(bic);
         }
      
         public DataTable payments(String lbl6)
         {
             bic = "SELECT pantientno as 'Patient No.',paydescription as 'Payments Description', payamount as 'Payment Amount' from payments where pantientno='" + lbl6 + "' and status=' 'and remarks='inpx'";
             return _code1(bic);
         }
        //con
    }
}
