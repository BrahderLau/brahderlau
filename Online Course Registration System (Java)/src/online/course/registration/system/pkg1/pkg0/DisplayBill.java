/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package online.course.registration.system.pkg1.pkg0;

import java.util.List;
import javax.swing.DefaultListModel;

/**
 *
 * @author Lau Kah Hou
 */
public class DisplayBill extends javax.swing.JFrame {
    Bill b1 = new Bill();
    Student s1 = new Student();
    DefaultListModel billModel;
    private List<String> bill_list;
    /**
     * Creates new form DisplayBill
     */
    public DisplayBill() {
        initComponents();
    }
    
    public DisplayBill(List<String> studentInfo) {
        initComponents();
        s1.studentInfo = studentInfo;
        this.id_lbl.setText(s1.studentInfo.get(0));
        this.name_lbl.setText(s1.studentInfo.get(2));
        b1.setStudent_id(s1.studentInfo.get(0));
        billModel = new DefaultListModel();
        this.bill_list = b1.generateBill();
        for (int i = 0; i < bill_list.size() ; i++){
            billModel.addElement(bill_list.get(i));
        }
        bill_listbox.setModel(billModel);
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        logout_btn = new javax.swing.JButton();
        bill_btn = new javax.swing.JButton();
        addCourse_btn = new javax.swing.JButton();
        manage_btn = new javax.swing.JButton();
        home_btn = new javax.swing.JButton();
        jLabel3 = new javax.swing.JLabel();
        jLabel4 = new javax.swing.JLabel();
        jLabel5 = new javax.swing.JLabel();
        name_lbl = new javax.swing.JLabel();
        id_lbl = new javax.swing.JLabel();
        jLabel6 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        bill_listbox = new javax.swing.JList<>();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(null);

        logout_btn.setFont(new java.awt.Font("Tempus Sans ITC", 1, 18)); // NOI18N
        logout_btn.setText("Log Out");
        logout_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                logout_btnActionPerformed(evt);
            }
        });
        getContentPane().add(logout_btn);
        logout_btn.setBounds(0, 518, 170, 62);

        bill_btn.setFont(new java.awt.Font("Tempus Sans ITC", 1, 18)); // NOI18N
        bill_btn.setText("Display Bill");
        bill_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bill_btnActionPerformed(evt);
            }
        });
        getContentPane().add(bill_btn);
        bill_btn.setBounds(0, 450, 170, 62);

        addCourse_btn.setFont(new java.awt.Font("Tempus Sans ITC", 1, 18)); // NOI18N
        addCourse_btn.setText("Add Course");
        addCourse_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                addCourse_btnActionPerformed(evt);
            }
        });
        getContentPane().add(addCourse_btn);
        addCourse_btn.setBounds(0, 382, 170, 62);

        manage_btn.setFont(new java.awt.Font("Tempus Sans ITC", 1, 18)); // NOI18N
        manage_btn.setText("Manage Profile");
        manage_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                manage_btnActionPerformed(evt);
            }
        });
        getContentPane().add(manage_btn);
        manage_btn.setBounds(0, 314, 170, 62);

        home_btn.setFont(new java.awt.Font("Tempus Sans ITC", 1, 18)); // NOI18N
        home_btn.setText("Home");
        home_btn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                home_btnActionPerformed(evt);
            }
        });
        getContentPane().add(home_btn);
        home_btn.setBounds(0, 246, 170, 62);

        jLabel3.setIcon(new javax.swing.ImageIcon(getClass().getResource("/online/course/registration/system/pkg1/pkg0/Images/john.png"))); // NOI18N
        getContentPane().add(jLabel3);
        jLabel3.setBounds(21, 0, 113, 130);

        jLabel4.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        jLabel4.setText("Name: ");
        getContentPane().add(jLabel4);
        jLabel4.setBounds(20, 140, 44, 17);

        jLabel5.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        jLabel5.setText("Student ID:");
        getContentPane().add(jLabel5);
        jLabel5.setBounds(20, 190, 72, 17);

        name_lbl.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        name_lbl.setText("John Shimone Peter");
        getContentPane().add(name_lbl);
        name_lbl.setBounds(20, 160, 130, 17);

        id_lbl.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        id_lbl.setText("TPXXXXXXX");
        getContentPane().add(id_lbl);
        id_lbl.setBounds(20, 210, 80, 17);

        jLabel6.setFont(new java.awt.Font("Tempus Sans ITC", 1, 24)); // NOI18N
        jLabel6.setText("Bill Statement");
        getContentPane().add(jLabel6);
        jLabel6.setBounds(280, 10, 170, 33);

        bill_listbox.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        bill_listbox.setModel(new javax.swing.AbstractListModel<String>() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public String getElementAt(int i) { return strings[i]; }
        });
        jScrollPane1.setViewportView(bill_listbox);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(180, 50, 360, 520);

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void logout_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_logout_btnActionPerformed
        student_login f1 = new student_login();
        this.hide();
        f1.pack();
        f1.setSize(499, 699);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_logout_btnActionPerformed

    private void bill_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bill_btnActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_bill_btnActionPerformed

    private void addCourse_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_addCourse_btnActionPerformed
        AddCourse f1 = new AddCourse(s1.studentInfo);
        this.hide();
        f1.pack();
        f1.setSize(597, 610);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_addCourse_btnActionPerformed

    private void manage_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_manage_btnActionPerformed

        Profile f1 = new Profile(s1.studentInfo);
        this.hide();
        f1.pack();
        f1.setSize(597, 610);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();

    }//GEN-LAST:event_manage_btnActionPerformed

    private void home_btnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_home_btnActionPerformed

        student_dashboard f1 = new student_dashboard(s1.studentInfo);
        this.hide();
        f1.pack();
        f1.setSize(597, 610);
        f1.setLocationRelativeTo(null);
        f1.setVisible(true);
        f1.getContentPane().requestFocusInWindow();
    }//GEN-LAST:event_home_btnActionPerformed

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
            java.util.logging.Logger.getLogger(DisplayBill.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(DisplayBill.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(DisplayBill.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(DisplayBill.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new DisplayBill().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton addCourse_btn;
    private javax.swing.JButton bill_btn;
    private javax.swing.JList<String> bill_listbox;
    private javax.swing.JButton home_btn;
    private javax.swing.JLabel id_lbl;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JLabel jLabel4;
    private javax.swing.JLabel jLabel5;
    private javax.swing.JLabel jLabel6;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JButton logout_btn;
    private javax.swing.JButton manage_btn;
    private javax.swing.JLabel name_lbl;
    // End of variables declaration//GEN-END:variables
}
