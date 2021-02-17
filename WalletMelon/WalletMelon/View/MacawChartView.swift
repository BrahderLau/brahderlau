//
//  ViewClass.swift
//  WalletMelon
//
//  Created by Lau Kah Hou on 29/10/2019.
//  Copyright © 2019 brahdertechz. All rights reserved.
//

import Foundation
import Macaw

class MacawChartView: MacawView {
    
    var showType: String = ""
    var viewCount: Double = 0.0
/*
    static let lastFiveShows = createQueryData()
    static let maxValue = 100
    static let maxValueLineHeight = 180
    static let lineWidth: Double = 275 //how long is the x-axis line to be
    
    static let dataDivisor = Double(maxValue/maxValueLineHeight)
    static let adjustedData: [Double] = lastFiveShows.map({$0.viewCount / dataDivisor})
    static var animatioons: [Animation] = []
    
    required init?(coder aDecoder: NSCoder) {
        super.init(node: MacawChartView.createChart(), coder: aDecoder)
        backgroundColor = .clear
    }
    
    private static func createChart() ->Group{ //group is an array of nodes
        var items: [Node] = addYAxisItems() + addXAxisItems()
        items.append(createBars())
        return Group(contents: items, place: .identity)
    }
    
    private static func addYAxisItems() -> [Node] {
        let maxLines = 6
        let lineInterval = Int(maxValue/maxLines)
        let yAxisHeight: Double = 200
        let lineSpacing: Double = 38
        
        var newNodes: [Node] = []
        
        for i in 1...maxLines{
            int y = yAxisHeight - (Double(i) * lineSpacing)
            
            let valueLine = Line(x1: -5, y1: y, x2: lineWidth, y2: y)
        }
        return[]
    }
    
    private static func addXAxisItems() -> [Node] {
        return[]
    }
    
    private static func createBars() -> Group {
        return Group()
    }
        
    private static func createQueryData(){
        
        let one     = (showType: "Food & Beverages", viewCount: 45)
        let two     = (showType: "Clothings", viewCount: 30)
        let three   = (showType: "Entertainments", viewCount: 15)
        let four    = (showType: "Others", viewCount: 10)
        
        return [one, two, three, four]
    }*/
}
