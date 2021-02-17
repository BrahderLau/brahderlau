//
//  Extension.swift
//  WalletMelon
//
//  Created by Lau Kah Hou on 31/10/2019.
//  Copyright © 2019 brahdertechz. All rights reserved.
//

import UIKit

extension UIViewController {
    func hideKeyboardWhenTappedAround(){
        let tapGesture = UITapGestureRecognizer(target: self, action: #selector(hideKeyboard))
        
        view.addGestureRecognizer(tapGesture)
        
    }
    
    @objc func hideKeyboard(){
        view.endEditing(true)
    }
}
