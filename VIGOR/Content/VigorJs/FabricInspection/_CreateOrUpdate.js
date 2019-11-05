function calculateValues(name) {
    debugger;
    var uniqueName = parseInt(name.match(/[0-9]+/)[0], 10);
   
    var RollOn = Number($('input[name="det[' + uniqueName + '][RollNo]"]').val());
    var NoteMeters = Number($('input[name="det[' + uniqueName + '][NotedMeters]"]').val());
    var ActualMeters = Number($('input[name="det[' + uniqueName + '][ActualMeters]"]').val());
    var SlubsKnotes = Number($('input[name="det[' + uniqueName + '][Slubknots]"]').val());
    var PolyYarnBlue = Number($('input[name="det[' + uniqueName + '][Warp1]"]').val());
    var PolyYarnRed = Number($('input[name="det[' + uniqueName + '][Weft1]"]').val());
    var Holes = Number($('input[name="det[' + uniqueName + '][Holes]"]').val());
    var MissPack1 = Number($('input[name="det[' + uniqueName + '][One5]"]').val());
    var MissPack2 = Number($('input[name="det[' + uniqueName + '][Two6]"]').val());
    var MissPack3 = Number($('input[name="det[' + uniqueName + '][Three7]"]').val());
    var MissPack4 = Number($('input[name="det[' + uniqueName + '][Four8]"]').val());
    var ThickDoublePick = Number($('input[name="det[' + uniqueName + '][Three1]"]').val());
    var ThickDoublePick2 = Number($('input[name="det[' + uniqueName + '][Ten2]"]').val());
    var ThickDoublePick3 = Number($('input[name="det[' + uniqueName + '][Eleven3]"]').val());
    var ThickDoublePick4 = Number($('input[name="det[' + uniqueName + '][Twelve4]"]').val());
    var WeftBar = Number($('input[name="det[' + uniqueName + '][WeftBar]"]').val());
    var LooseEndsThickEnds1 = Number($('input[name="det[' + uniqueName + '][Fourteen1]"]').val());
    var LooseEndsThickEnds2 = Number($('input[name="det[' + uniqueName + '][Fifteen2]"]').val());
    var LooseEndsThickEnds3 = Number($('input[name="det[' + uniqueName + '][Sixteen3]"]').val());
    var LooseEndsThickEnds4 = Number($('input[name="det[' + uniqueName + '][Seventeen4]"]').val());
    var ReedMarkBrokenEndsWrap1 = Number($('input[name="det[' + uniqueName + '][EightOne]"]').val());
    var ReedMarkBrokenEndsWrap2 = Number($('input[name="det[' + uniqueName + '][Ninteen2]"]').val());
    var ReedMarkBrokenEndsWrap3 = Number($('input[name="det[' + uniqueName + '][Twenty3]"]').val());
    var ReedMarkBrokenEndsWrap4 = Number($('input[name="det[' + uniqueName + '][TwOn4]"]').val());
    var TotalPointsPerRoll = Number($('input[name="det[' + uniqueName + '][TPointRoll]"]').val());
    var Points100SqYards = Number($('input[name="det[' + uniqueName + '][PointsSqy]"]').val());
    var FabricGrade = $('input[name="det[' + uniqueName + '][FabricGrade]"]').val();
    var ActualWidth = Number($('input[name="det[' + uniqueName + '][ActualWidth]"]').val());
    var Ends = Number($('input[name="det[' + uniqueName + '][Ends]"]').val());
    var Pick = Number($('input[name="det[' + uniqueName + '][Pick]"]').val());
    var NoOfCutFault = Number($('input[name="det[' + uniqueName + '][CutFaults]"]').val());
    var MildWetBar = Number($('input[name="det[' + uniqueName + '][MildWeft]"]').val());
    var SmallslubKnotes = Number($('input[name="det[' + uniqueName + '][SmallSlubKnits]"]').val());
    var ActualGramSqr = Number($('input[name="det[' + uniqueName + '][TotalPoints]"]').val());


    // start For Yard Base Calculation 
    TotalPointsPerRoll = ((SlubsKnotes + PolyYarnRed + PolyYarnBlue + MissPack1 + ThickDoublePick + LooseEndsThickEnds1 + ReedMarkBrokenEndsWrap1) +
        ((MissPack2 + ThickDoublePick2 + LooseEndsThickEnds2 + ReedMarkBrokenEndsWrap2) * 2) +
        ((MissPack3 + ThickDoublePick3 + LooseEndsThickEnds3 + ReedMarkBrokenEndsWrap3) * 3) +
        ((Holes + MissPack4 + ThickDoublePick4 + WeftBar + LooseEndsThickEnds4 + ReedMarkBrokenEndsWrap4) * 4));

    $('input[name="det[' + uniqueName + '][TPointRoll]"]').val(Math.round(TotalPointsPerRoll));


    if (ActualWidth <= 0) {
        $('input[name="det[' + uniqueName + '][ActualWidth]"]').val(1);
    } 

    Points100SqYards = ((TotalPointsPerRoll * 3600) / (ActualMeters *ActualWidth * 1.093611)).toFixed(2);
    $('input[name="det[' + uniqueName + '][PointsSqy]"]').val(Math.round(Points100SqYards));

    if (Points100SqYards <= 15) {
        $('input[name="det[' + uniqueName + '][FabricGrade]"]').val("A");
    } else {
        $('input[name="det[' + uniqueName + '][FabricGrade]"]').val("B");
    }

    ActualGramSqr = ((TotalPointsPerRoll * 3600) / (ActualMeters * ActualWidth * 1.093611)).toFixed(2);
    $('input[name="det[' + uniqueName + '][TotalPoints]"]').val(Math.round(ActualGramSqr));

    // END For Yard Base Calculation 

    //START For Meter Base Calculation 
       // END For Meter Base Calculation 
}

