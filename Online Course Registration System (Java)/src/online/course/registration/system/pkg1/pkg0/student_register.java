
package online.course.registration.system.pkg1.pkg0;

import java.io.FileWriter;
import java.util.regex.Pattern;
import javax.swing.JOptionPane;



        
public class student_register extends javax.swing.JFrame {

    
    public student_register() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jTextField1 = new javax.swing.JTextField();
        jComboBox1 = new javax.swing.JComboBox<>();
        jLabel1 = new javax.swing.JLabel();
        Register_btn = new javax.swing.JButton();
        Cancel_btn = new javax.swing.JButton();
        TPno_txt = new javax.swing.JTextField();
        Name_txt = new javax.swing.JTextField();
        Phoneno_txt = new javax.swing.JTextField();
        Emailaddress_txt = new javax.swing.JTextField();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jLabel8 = new javax.swing.JLabel();
        jLabel9 = new javax.swing.JLabel();
        Password_txt = new javax.swing.JPasswordField();
        Degreelvl_combobox = new javax.swing.JComboBox<>();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextPane1 = new javax.swing.JTextPane();
        student_reg = new javax.swing.JButton();
        manageprofile_btn = new javax.swing.JButton();
        jButton1 = new javax.swing.JButton();
        Adminhome_btn = new javax.swing.JButton();
        jLabel7 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();

        jTextField1.setText("jTextField1");

        jComboBox1.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(null);

        jLabel1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/student reg.jpg"))); // NOI18N
        getContentPane().add(jLabel1);
        jLabel1.setBounds(300, 40, 310, 100);

        Register_btn.setFont(new java.awt.Font("Tw Cen MT", 0, 18)); // NOI18N
        Register_btn.setText("Register");
        Register_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Register_btnActionPerformed(evt);
            }
        });
        getContentPane().add(Register_btn);
        Register_btn.setBounds(410, 480, 130, 29);

        Cancel_btn.setFont(new java.awt.Font("Tw Cen MT", 0, 18)); // NOI18N
        Cancel_btn.setText("Cancel");
        Cancel_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Cancel_btnActionPerformed(evt);
            }
        });
        getContentPane().add(Cancel_btn);
        Cancel_btn.setBounds(550, 480, 130, 29);

        TPno_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        getContentPane().add(TPno_txt);
        TPno_txt.setBounds(330, 200, 180, 29);

        Name_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        getContentPane().add(Name_txt);
        Name_txt.setBounds(330, 240, 180, 29);

        Phoneno_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        getContentPane().add(Phoneno_txt);
        Phoneno_txt.setBounds(350, 320, 170, 29);

        Emailaddress_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        getContentPane().add(Emailaddress_txt);
        Emailaddress_txt.setBounds(390, 360, 160, 29);

        jLabel3.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel3.setText("TP No:");
        getContentPane().add(jLabel3);
        jLabel3.setBounds(270, 200, 80, 23);

        jLabel4.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel4.setText("Name:");
        getContentPane().add(jLabel4);
        jLabel4.setBounds(270, 240, 90, 23);

        jLabel5.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel5.setText("Portal Login Password:");
        getContentPane().add(jLabel5);
        jLabel5.setBounds(270, 400, 190, 23);

        jLabel6.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel6.setText("Phone No:");
        getContentPane().add(jLabel6);
        jLabel6.setBounds(270, 320, 110, 23);

        jLabel8.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel8.setText("Degree Level:");
        getContentPane().add(jLabel8);
        jLabel8.setBounds(270, 280, 120, 23);

        jLabel9.setFont(new java.awt.Font("Tw Cen MT", 0, 20)); // NOI18N
        jLabel9.setText("Email Address:");
        getContentPane().add(jLabel9);
        jLabel9.setBounds(270, 360, 130, 23);

        Password_txt.setFont(new java.awt.Font("Tw Cen MT", 0, 18)); // NOI18N
        getContentPane().add(Password_txt);
        Password_txt.setBounds(450, 400, 160, 30);

        Degreelvl_combobox.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "1", "2", "3", " " }));
        getContentPane().add(Degreelvl_combobox);
        Degreelvl_combobox.setBounds(390, 280, 34, 22);

        jTextPane1.setDragEnabled(true);
        jTextPane1.setEnabled(false);
        jScrollPane1.setViewportView(jTextPane1);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(240, 160, 460, 420);

        student_reg.setText("Student Registration");
        student_reg.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                student_regActionPerformed(evt);
            }
        });
        getContentPane().add(student_reg);
        student_reg.setBounds(0, 380, 160, 60);

        manageprofile_btn.setText("Manage Profile");
        manageprofile_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                manageprofile_btnActionPerformed(evt);
            }
        });
        getContentPane().add(manageprofile_btn);
        manageprofile_btn.setBounds(0, 460, 160, 60);

        jButton1.setText("Logout");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
        getContentPane().add(jButton1);
        jButton1.setBounds(0, 530, 160, 60);

        Adminhome_btn.setText("Home");
        Adminhome_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                Adminhome_btnActionPerformed(evt);
            }
        });
        getContentPane().add(Adminhome_btn);
        Adminhome_btn.setBounds(0, 310, 160, 60);

        jLabel7.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/Lecturer.png"))); // NOI18N
        getContentPane().add(jLabel7);
        jLabel7.setBounds(40, 20, 180, 170);

        jLabel2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/student_background.jpg"))); // NOI18N
        getContentPane().add(jLabel2);
        jLabel2.setBounds(-100, -10, 1090, 680);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void Register_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Register_btnActionPerformed
        String TPno = TPno_txt.getText();
        String Name = Name_txt.getText();
        String Degreelvl = (String)Degreelvl_combobox.getSelectedItem();
        String Phoneno = Phoneno_txt.getText();
        String Emailadd = Emailaddress_txt.getText();
        String Password = Password_txt.getText();
        
        if(TPno.equals("")||Name.equals("")||Phoneno.equals("")||Emailadd.equals("")||Password.equals("")){
            JOptionPane.showMessageDialog(null, "Please fill in the relevant field(s).");
        }
        
        else if (!(Pattern.matches("^[a-zA-Z0-9]+[@]{1}+[a-zA-Z0-9]+[.]{1}+[a-zA-Z0-9]+$", Emailaddress_txt.getText()))) 
        {
            JOptionPane.showMessageDialog(null, "Please enter a valid email", "Error", JOptionPane.ERROR_MESSAGE);

            if (!(Pattern.matches("\\d{3}-\\d{7}", Phoneno_txt.getText()))) 
            {
                JOptionPane.showMessageDialog(null, "Please enter a valid phone number", "Error", JOptionPane.ERROR_MESSAGE);
            }
        }
        else{
            JOptionPane.showMessageDialog(rootPane,"Register Successful!");
            admin_page f1 = new admin_page();
            this.hide();
            f1.pack();
            f1.setSize(960, 660);
            f1.setLocationRelativeTo(null);
            f1.setVisible(true);
            f1.getContentPane().requestFocusInWindow();
        }

        try{
            FileWriter writer = new FileWriter("Student.txt",true);
            writer.write(System.getProperty("line.separator"));
            writer.write(TPno + ",");
            writer.write(Password+ ",");
            writer.write(Name + ",");
            writer.write(Degreelvl + ",");
            writer.write(Phoneno + ",");
            writer.write(Emailadd);
            writer.close();
        } catch (Exception e){
            JOptionPane.showMessageDialog(rootPane,"Invalid!");
        }
        
        
    }//GEN-LAST:event_Register_btnActionPerformed

    private void Cancel_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_Cancel_btnActionPerformed
            //int YesOrNo = JOptionPane.showConfirmDialog(null,"Do you want to cancel","Back to Main page", JOptionPane.QUESTION_MESSAGE, JOptionPane.YES_NO_OPTION);
            //if (YesOrNo == 0)
            //{
            admin_page f1 = new admin_page();
            this.hide();
            f1.pack();
            f1.setSize(592, 610);
            f1.setLocationRelativeTo(null);
            f1.setVisible(true);
            f1.getContentPane().requestFocusInWindow();
            //} else{
            //    JOptionPane.showMessageDialog(rootPane,"Register Successful!");
            //}
        
    }//GEN-LAST:event_Cancel_btnActionPerformed

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        admin_login f1 = new admin_login();
        this.hide();
        f1.pack();
        f1.setSize(699, 500);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_jButton1ActionPerformed

    private void student_regActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_student_regActionPerformed
        student_register f1 = new student_register();
        this.hide();
        f1.pack();
        f1.setSize(1000, 720);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_student_regActionPerformed

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
            java.util.logging.Logger.getLogger(student_register.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(student_register.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(student_register.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(student_register.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new student_register().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton Adminhome_btn;
    private javax.swing.JButton Cancel_btn;
    private javax.swing.JComboBox<String> Degreelvl_combobox;
    private javax.swing.JTextField Emailaddress_txt;
    private javax.swing.JTextField Name_txt;
    private javax.swing.JPasswordField Password_txt;
    private javax.swing.JTextField Phoneno_txt;
    private javax.swing.JButton Register_btn;
    private javax.swing.JTextField TPno_txt;
    private javax.swing.JButton jButton1;
    private javax.swing.JComboBox<String> jComboBox1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JLabel jLabel7;
    private javax.swing.JLabel jLabel8;
    private javax.swing.JLabel jLabel9;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField jTextField1;
    private javax.swing.JTextPane jTextPane1;
    private javax.swing.JButton manageprofile_btn;
    private javax.swing.JButton student_reg;
    // End of variables declaration//GEN-END:variables
}
