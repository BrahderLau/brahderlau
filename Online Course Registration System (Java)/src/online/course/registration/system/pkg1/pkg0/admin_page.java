/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package online.course.registration.system.pkg1.pkg0;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javax.swing.DefaultComboBoxModel;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;

/**
 *
 * @author lexin
 */
public class admin_page extends javax.swing.JFrame {

    Course c1 = new Course();
    private List<String> courseInfo;
    private List<String> detailsList;
    private Scanner x;
    
    public admin_page() {
        initComponents();
        c1.GetCourseInfo();
        this.courseInfo = c1.SetCourse();
        courseComboBox.setModel(new DefaultComboBoxModel(courseInfo.toArray()));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        student_reg = new javax.swing.JButton();
        manageprofile_btn = new javax.swing.JButton();
        jButton1 = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        Adminhome_btn = new javax.swing.JButton();
        search_btn = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        student_list = new javax.swing.JList<>();
        jLabel2 = new javax.swing.JLabel();
        add_btn = new javax.swing.JButton();
        delete_btn = new javax.swing.JButton();
        edit_btn = new javax.swing.JButton();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel7 = new javax.swing.JLabel();
        coursetitle_txt = new javax.swing.JTextField();
        courselvl_txt = new javax.swing.JTextField();
        duration_txt = new javax.swing.JTextField();
        courseComboBox = new javax.swing.JComboBox<>();
        jLabel8 = new javax.swing.JLabel();
        coursefee_txt = new javax.swing.JTextField();
        jLabel9 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(null);

        student_reg.setText("Student Registration");
        student_reg.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                student_regActionPerformed(evt);
            }
        });
        getContentPane().add(student_reg);
        student_reg.setBounds(12, 404, 170, 53);

        manageprofile_btn.setText("Manage Profile");
        manageprofile_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                manageprofile_btnActionPerformed(evt);
            }
        });
        getContentPane().add(manageprofile_btn);
        manageprofile_btn.setBounds(12, 475, 170, 48);

        jButton1.setText("Logout");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
        getContentPane().add(jButton1);
        jButton1.setBounds(12, 541, 170, 46);

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/Lecturer.png"))); // NOI18N
        getContentPane().add(jLabel1);
        jLabel1.setBounds(32, 25, 110, 127);

        Adminhome_btn.setText("Home");
        Adminhome_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Adminhome_btnActionPerformed(evt);
            }
        });
        getContentPane().add(Adminhome_btn);
        Adminhome_btn.setBounds(12, 338, 170, 53);

        search_btn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/icons8_search_32px_2.png"))); // NOI18N
        search_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                search_btnActionPerformed(evt);
            }
        });
        getContentPane().add(search_btn);
        search_btn.setBounds(570, 40, 40, 40);

        student_list.setModel(new javax.swing.AbstractListModel<String>() {
            String[] strings = { " " };
            public int getSize() { return strings.length; }
            public String getElementAt(int i) { return strings[i]; }
        });
        jScrollPane1.setViewportView(student_list);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(207, 135, 362, 430);

        jLabel2.setFont(new java.awt.Font("Tw Cen MT", 1, 24)); // NOI18N
        jLabel2.setText("Course Registered by Students");
        getContentPane().add(jLabel2);
        jLabel2.setBounds(215, 101, 336, 27);

        add_btn.setText("Add");
        add_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                add_btnActionPerformed(evt);
            }
        });
        getContentPane().add(add_btn);
        add_btn.setBounds(660, 440, 80, 23);

        delete_btn.setText("Delete");
        delete_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                delete_btnActionPerformed(evt);
            }
        });
        getContentPane().add(delete_btn);
        delete_btn.setBounds(830, 440, 90, 23);

        edit_btn.setText("Edit");
        edit_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                edit_btnActionPerformed(evt);
            }
        });
        getContentPane().add(edit_btn);
        edit_btn.setBounds(750, 440, 70, 23);

        jLabel3.setFont(new java.awt.Font("Tw Cen MT", 1, 24)); // NOI18N
        jLabel3.setText("Course Details");
        getContentPane().add(jLabel3);
        jLabel3.setBounds(701, 141, 144, 27);

        jLabel4.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        jLabel4.setText("Course Title:");
        getContentPane().add(jLabel4);
        jLabel4.setBounds(627, 206, 90, 18);

        jLabel6.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        jLabel6.setText("Course Level:");
        getContentPane().add(jLabel6);
        jLabel6.setBounds(650, 260, 83, 18);

        jLabel7.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        jLabel7.setText("Duration:");
        getContentPane().add(jLabel7);
        jLabel7.setBounds(650, 300, 57, 18);

        coursetitle_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        getContentPane().add(coursetitle_txt);
        coursetitle_txt.setBounds(717, 203, 190, 24);

        courselvl_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        getContentPane().add(courselvl_txt);
        courselvl_txt.setBounds(740, 260, 172, 24);

        duration_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        getContentPane().add(duration_txt);
        duration_txt.setBounds(720, 300, 172, 24);

        courseComboBox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));
        courseComboBox.setPreferredSize(null);
        courseComboBox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                courseComboBoxActionPerformed(evt);
            }
        });
        getContentPane().add(courseComboBox);
        courseComboBox.setBounds(190, 40, 380, 40);

        jLabel8.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        jLabel8.setText("Course Fee:");
        getContentPane().add(jLabel8);
        jLabel8.setBounds(650, 350, 74, 18);

        coursefee_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 16)); // NOI18N
        getContentPane().add(coursefee_txt);
        coursefee_txt.setBounds(730, 350, 172, 24);

        jLabel9.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/adminback.jpg"))); // NOI18N
        jLabel9.setText("jLabel9");
        getContentPane().add(jLabel9);
        jLabel9.setBounds(-50, 0, 1010, 620);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void student_regActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_student_regActionPerformed
        student_register f1 = new student_register();
        this.hide();
        f1.pack();
        f1.setSize(1000, 720);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_student_regActionPerformed

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        admin_login f1 = new admin_login();
        this.hide();
        f1.pack();
        f1.setSize(699, 500);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_jButton1ActionPerformed

    private void manageprofile_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_manageprofile_btnActionPerformed
        Manage_profile f1 = new Manage_profile();
        this.hide();
        f1.pack();
        f1.setSize(1000, 650);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_manageprofile_btnActionPerformed

    private void Adminhome_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Adminhome_btnActionPerformed
        admin_page f1 = new admin_page();
        this.hide();
        f1.pack();
        f1.setSize(960, 660);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_Adminhome_btnActionPerformed

    private void courseComboBoxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_courseComboBoxActionPerformed
        // TODO add your handling code here:
        
    }//GEN-LAST:event_courseComboBoxActionPerformed

    private void add_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_add_btnActionPerformed
        // TODO add your handling code here:
        boolean found = false;
        for (String s: courseInfo){
            if (coursetitle_txt.getText().equals(s)){
                JOptionPane.showMessageDialog(null,"Course already exist.");
                found = true;
                break;
            }
        }
        if(found == false){
            try{
                FileWriter writer = new FileWriter("Course.txt",true);
                writer.write(System.getProperty("line.separator"));
                writer.write(coursetitle_txt.getText() + ",");
                writer.write(courselvl_txt.getText()+ ",");
                writer.write(duration_txt.getText()+ ",");
                writer.write(coursefee_txt.getText()+ ",");
                writer.close();
            } catch (Exception e){
                JOptionPane.showMessageDialog(rootPane,"Invalid!");
            }
        }
    }//GEN-LAST:event_add_btnActionPerformed

    private void edit_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_edit_btnActionPerformed
        EditFile f = new EditFile();
        List<String> tempList = new ArrayList();
        tempList.add(coursetitle_txt.getText());
        tempList.add(courselvl_txt.getText());
        tempList.add(duration_txt.getText());
        tempList.add(coursefee_txt.getText());
        f.changeALineInATextFile("Course.txt",f.arrayListToString(tempList), coursetitle_txt.getText());
        JOptionPane.showMessageDialog(null,"Course edited successful.");
        this.hide();
        admin_page f1 = new admin_page();  
        f1.pack();
        f1.setSize(960, 660);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
        
    }//GEN-LAST:event_edit_btnActionPerformed

    private void search_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_search_btnActionPerformed
        // TODO add your handling code here:
        
            DefaultListModel sList = new DefaultListModel();//Model
            List<String> tempList = new ArrayList();
            detailsList = c1.generateDetails(courseComboBox.getSelectedItem().toString());
            if(detailsList.isEmpty()){ 
                //Do nothing.
            }
            else{
                coursetitle_txt.setText(detailsList.get(0));
                courselvl_txt.setText(detailsList.get(1));
                duration_txt.setText(detailsList.get(2));
                coursefee_txt.setText(detailsList.get(3));
                tempList = c1.getStudentList(coursetitle_txt.getText());
                for (String s: tempList){

                    sList.addElement(s);
                }
                student_list.setModel(sList);
        }
    }//GEN-LAST:event_search_btnActionPerformed

    private void delete_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_delete_btnActionPerformed
        List<String> tempList = new ArrayList();
        EditFile f = new EditFile();
        f.changeALineInATextFile("Course.txt", "", coursetitle_txt.getText());
        try{
            x = new Scanner(new BufferedReader (new FileReader("Student.txt")));
            x.useDelimiter("[,\n]"); //String pattern in the textfile
            while (x.hasNext()){
                String line = x.nextLine();
                if (line.isEmpty()){
                    continue;
                }
                else if(line.contains(coursetitle_txt.getText())){
                    String[] tokens = line.split(",");
                    for (String token : tokens){
                        if (token.isEmpty())
                            continue;
                        // do whatever processing for each token
                        else{
                            tempList.add(token);
                        }
                    }
                    for (String s: tempList){
                        if (s.equals(coursetitle_txt.getText())){
                            tempList.remove(s);
                            JOptionPane.showMessageDialog(null,tempList);
                            f.changeALineInATextFile("Student.txt", f.arrayListToString(tempList), coursetitle_txt.getText());
                            break;
                        }
                    }
                }
            }
            JOptionPane.showMessageDialog(null,"Course deleted successful.");
        }
        catch(FileNotFoundException e){
            JOptionPane.showMessageDialog(null,e);
        } 
        this.hide();
        admin_page f1 = new admin_page();  
        f1.pack();
        f1.setSize(960, 660);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_delete_btnActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(admin_page.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(admin_page.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(admin_page.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(admin_page.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new admin_page().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton Adminhome_btn;
    private javax.swing.JButton add_btn;
    private javax.swing.JComboBox<String> courseComboBox;
    private javax.swing.JTextField coursefee_txt;
    private javax.swing.JTextField courselvl_txt;
    private javax.swing.JTextField coursetitle_txt;
    private javax.swing.JButton delete_btn;
    private javax.swing.JTextField duration_txt;
    private javax.swing.JButton edit_btn;
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JButton manageprofile_btn;
    private javax.swing.JButton search_btn;
    private javax.swing.JList<String> student_list;
    private javax.swing.JButton student_reg;
    // End of variables declaration//GEN-END:variables
}
