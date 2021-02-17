//
//  LoginVC.swift
//  WalletMelon
//
//  Created by Lau Kah Hou on 28/10/2019.
//  Copyright © 2019 brahdertechz. All rights reserved.
//

import UIKit
import Firebase
import FirebaseAuth


class LoginVC: UIViewController {

    //References: https://www.youtube.com/watch?v=9xnblG4V1LQ
    
    @IBOutlet weak var phoneTxt: UITextField!
    @IBOutlet weak var otpTxt: UITextField!
    
    //constant
    let userDefault = UserDefaults.standard
    
    @IBAction func sendCodeIsClicked(_ sender: Any) {
        
        guard let phoneNumber = phoneTxt.text else {return}
        
        PhoneAuthProvider.provider().verifyPhoneNumber(phoneNumber, uiDelegate: nil) { (verificationId, error) in
            if error == nil{
                print(verificationId)
                guard let verifyId = verificationId else { return }
                self.userDefault.set(verifyId, forKey: "verificationId")
                self.userDefault.synchronize()
            }else{
                print("Unable to get Secret Verification Code from firebase", error?.localizedDescription)
            }
        }
    }
    
    
    @IBAction func loginIsClicked(_ sender: Any) {
        
        guard let otpCode = otpTxt.text else { return }
       
        guard let verificationId = userDefault.string(forKey: "verificationId") else { return }
            
        let credential = PhoneAuthProvider.provider().credential(withVerificationID: verificationId, verificationCode: otpCode)
        
        Auth.auth().signInAndRetrieveData(with: credential) { (success, error) in
            if error == nil{
                print(success)
                print("User Signed in...")
            }
            else{
                print("Something went wrong...\(error?.localizedDescription)")
            }
        }
    }
    
    override func viewDidLoad() {
        FirebaseApp.configure()
        hideKeyboardWhenTappedAround()
        super.viewDidLoad()
    }

        // Do any additional setup after loading the view.

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
