<?xml version="1.0" encoding="UTF-8"?>
<Form xmlVersion="20170720" releaseVersion="10.0.0">
<TableDataMap>
<TableData name="储存链" class="com.fr.data.impl.DBTableData">
<Parameters/>
<Attributes maxMemRowCount="-1"/>
<Connection class="com.fr.data.impl.NameDatabaseConnection">
<DatabaseName>
<![CDATA[江夏测试]]></DatabaseName>
</Connection>
<Query>
<![CDATA[SELECT d.BinCode,d.Barcode,d.CreateTime,d.PartNo,p.BriefDesc,p.BackColor,p.ForeColor FROM WMS_ProductBinDet d 
LEFT JOIN V_MFG_Part p ON p.PartNo = d.PartNo  
WHERE d.BinCode<>'bbb' and d.BinCode IN(SELECT BinCode FROM WMS_Bin WHERE ShelfCode='SHXGL')
ORDER BY d.BinCode DESC,d.CreateTime desc]]></Query>
<PageQuery>
<![CDATA[]]></PageQuery>
</TableData>
<TableData name="静置链" class="com.fr.data.impl.DBTableData">
<Parameters/>
<Attributes maxMemRowCount="-1"/>
<Connection class="com.fr.data.impl.NameDatabaseConnection">
<DatabaseName>
<![CDATA[江夏测试]]></DatabaseName>
</Connection>
<Query>
<![CDATA[SELECT d.BinCode,d.Barcode,d.CreateTime,d.PartNo,p.BriefDesc,p.BackColor,p.ForeColor FROM WMS_ProductBinDet d 
LEFT JOIN V_MFG_Part p ON p.PartNo = d.PartNo  
WHERE d.BinCode='bbb' ORDER BY d.BinCode DESC,d.CreateTime desc]]></Query>
<PageQuery>
<![CDATA[]]></PageQuery>
</TableData>
</TableDataMap>
<FormMobileAttr>
<FormMobileAttr refresh="false" isUseHTML="false" isMobileOnly="false" isAdaptivePropertyAutoMatch="false" appearRefresh="false" promptWhenLeaveWithoutSubmit="false"/>
</FormMobileAttr>
<Parameters/>
<Layout class="com.fr.form.ui.container.WBorderLayout">
<WidgetName name="form"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Center class="com.fr.form.ui.container.WFitLayout">
<WidgetName name="body"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.container.WTitleLayout">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1152000,723900,800100,723900,723900,723900,762000,799200,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[2362200,2209800,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="0" s="0">
<O>
<![CDATA[静置链]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="Barcode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Result>
<![CDATA[=$$$]]></Result>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "Red"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "LightBlue"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-10053121"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Silver]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "Silver"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-2631719"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "Gray"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-6908266"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Blue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "Blue"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[静置链.select(BackColor, BarCode = B3) = "White"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="1"/>
</C>
<C c="0" r="6" rs="2" s="3">
<O>
<![CDATA[汇总:]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="6" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037043]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037055]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-10053121"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Silver]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037061]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-2631719"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037067]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-6908266"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037073]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037323]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="1" leftParentDefault="false" upParentDefault="false" order="1">
<SortFormula>
<![CDATA[=b7]]></SortFormula>
</Expand>
</C>
<C c="1" r="7" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="0"/>
</C>
<C c="1" r="8" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.SummaryGrouper">
<FN>
<![CDATA[com.fr.data.util.function.CountFunction]]></FN>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
<WorkSheetAttr direction="1" start="1" oppoStart="2" end="1" oppoEnd="2" maxRowOrColumn="8"/>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="120"/>
<Background name="ColorBackground" color="-3342388"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="ColorBackground" color="-13210"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="NullBackground"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="96"/>
<Background name="NullBackground"/>
<Border/>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[m9=p^'4nnt$f3jH=-iP.9%N$;O7na%'tU5UEYdJ2"Idl8V+jNd&A.%e#b`haD@3O0RYC*3Bn
atD\dM[-[^!1sUs8#;&g@eP.&@B71ndLq+UL`/9[hcQB*.?*b`"0pLY[A"Gl$o"BBG]APqu,C
?rOq[gS%eK`U1`r/l[cZ[ba<DEP38E^EQ3rAW&&&@r9,01TtgDCCX,j7Aj#h]AP%T6S@d@@HL
h?8XP(jJsbCA%>jAG:rWi@-uHZ/TEqa:8=J(+!qQtL<XS,L5%Z2+,i0k:gorkVsTElZ@AhYP
E:KsieX7oU*[mtp<JHen_/.?!>,*i^*VX7K1%PD<Z<Qk#6rJh"H)P(nL_,c1NcCoT8eP]A..U
3H0L4.!H.:H/QfD\M4lZ(39i2!SVXEn4hkIhmrj%^U#o.;NOUI#BjAFn/?e'Gbng,a\+RAIB
B/8W]A/S^ps2(spH_^/4K#.B,`,K-n]A:HR!BaeG=\5AJi[bncNp<=cdGH"Q_bWS<T3(i6,GRK
KSBC<cYFciiHg3VaH8/5.<I:b2lQ9e(AT0n$q8,QBK'p[RnZrYgr=Y2-Z,>k:3p;#t!kN)Uo
(\""c&7-H"_-B]Aonj.NKD"onP_+NqrSRe&-OkT8\k2WenccfdXWB&/9]AT#+o03@j,HEbb&_!
HMo7KKp\RkGn7H`X)3\e8)TWt7U9$)#Mno8)#VHQtH8=i\3.:c&!3cLTq<T$H,/^9gFfu`hJ
SatZ7#3F*:5b3sudJo9B6SGUur&g(/=iIFj&]Ag1i=L90O'Xu2Q:I-9HL*6;a&nr,h!aX)f#p
%TFYWuk2%D,8jS6O>D,SOGSP#\JcO&t`tE]AS$p`hUKt9LQ-"NAfFV>%?"[A^S*)HW8<q<9BX
O9k)%=rF08*ArsL4m*EYu0Kf!n<W:'d-,OIJZ72r#/4:9kmB#3?hQe&u015?hKZF(T$Pp;2Z
-H_"Vu0@a@Pe0@Q12/Y?6Ug[P1$A:`QMfU3_hsf>(/QCA4McO]A4Z;O;UGF)SO-p_rkZDs_P0
"+btqot3dC!CWe-J%=nm0&)hoSu:kq/O3H"j>nBA?Q0futUG(J]AKS\h,dFXbBKllCTP(1be!
qk$+/J_kP.)DF$^mssFF,g(F6QH/hrnFf1LGF.>+4&\A07;4ml!C^,jN\#StZLAhcPNnY:Be
]AoC\I.:1ZR'>X"4X.+1A%KA$U0kOOt@?e=o5Bj5Ht(I$p[m]A*;;CgM/2.(FZN,M3+rsOg;U<
'Iu?;Go!c]A:Kh9U'VPm_AEjl%jh6b,M!l\IY%<6P++G#!@Y24!\[1D90)<_@HSarZ4im'ZCJ
OPP[hS,DD9.eOo@2^[5a("8B#)0!6efkh:@?3$L#*R(p;7W>O]A-JD!)"``1>nt>4WX=6o/4Z
U!DNfWs@\#Y93TS8VjZ^m\3!LkOdBG?[9_f-*/1bF2I=ne-n*2(VSnM7#r3uG#fn1]AcROihL
U]A?S*_2nNF3<1mW4E&f-*HFjtREA,=BsPHe13.WqPh4,/'o8I#NdH1M><%(VFZd/YMb7&!,I
.+I;Nm<]Ag;PSsRIi/da'aVBaB$UebPq#JMWAZd/NsoS`Q]As>:ofp9a%hOo@tt9kYZ%5ofjWo
fE'Kasa4L=SLf>bMY(kse\lrq<VOF:fZ5MG=ZW7EfERNU-9@[b&_U/Nd><K-aPEZ(Jl0go9A
84O\1ipNDMSt.-=:L$=npF</TM<H?Cj#F6G&I=/"7jl?gj3SV/+46s=6h6(#Cje9V>;SJ4HZ
eE3MIN@`?X3!kG<K<cTs#.EZ)``cU)Jpa@TF/"7*Y;O3K5DfK(-hU"Lj&&'g.F>%G@(BsK]A:
SFb^uLQ@O4f#>WZJeVM`q/Od%9.gj$LSOGdi'r[HKB%8+6Ir&hAI1akZ]Ah6W2.eH61&^QO/b
#k\<J@s9e5-fJg<9G-?ENcg>Rj=@'a^8ZSqkbqKdaB"Ah-C;7pLcNAK<T4BJb0HVH7d1cjCa
D+FhY1MBh'kA!JK[DAA&@h:T5qCDD:>a0/*!]A`b1Cq)GRZaJGW`H5:9.?>YU'@g!<[pJk#A\
VYMr3:/"dYV;QXdH*Wb\;Ygre,ER;jd!+S18Y[*OtQ\QT(@M\DFQb97A80QW!*7Hn0kjG4=0
M>qikq2jXB2enoaJ6!+T%35!kY=C/T9i:]A"M'8W&2Y4?sNLIes_*<^.]AV'.)P>fbALJd9iH<
'd.;iPrR1NB)pq"A>S382VsJJHg<BdKp(mdqRXlmO9Mti'V%9k-l4/(*#h<LqjS#*UH,HtFP
,6GE5U@.5#,XgF/^;L6Ds&:GoK`hLPJ.KN$19q+7%Hk2IU]AL'?#5_E&OF`!_C%,i1/GFM>N4
);&o]A^n6m01s%;\.I=XoWiA?8+]A"4p[0mn$+s6?9_B9SG((K[a92I4uV8TPp>6@7@jd-hdK>
lfuZn:k$BUM#T*OM\%#rMI<3!b5?J-irR)HIC.]AIS,b-5"89C5.k?ANTku83)Fi3U9FR6j7f
btNe;.ZWF.7-PZ@&JWZ#MBlQ*cuLo$!@S_lC[<JJ-COWs_p="q\:ok5fB\+b&R>srBQfH+(G
fU&G1=1WD6S-h+\Z/pSImHL[%1j:8>9$lMrCos>=Loq$:KfF_1:'V\ehX,p&=OZZ>!CU-D4P
=R:[C,A(jE$FS$'=+5:6%GIf^p<_")6[b+"Fe`e]A?gAq>H;sA^s'0[4rt.b0kjQ[8X+:`T#m
aFJ&g7No`%L4jsrOM<$t=rY_kq)4\XUdj@V\#S*=:L$WG!4/_)L1`JfDMc4WUSZbrNEWG/R2
=d**!*P=*`Hme!jEZSMdYd$F;GqkBWeJiRrNNk<+D[I(]A+TC`6pMSuqGk@BPGBj",3_LX#YQ
_)-\DVl+?"IbNF.CYKP8"#/Ql%.W`O,q>fAcElo[BUT$FRf6uc1_884S_2QCG+='-"Q*VC@.
:hDar`h8M0rf+Kb(]Anl>kNBAhAC2me(IN-UAn_nZ^6SMgW-lcN;<\:Q!:`,j8mO8YQ\"F62A
XKsk"lePc27d=pi`->Gd*gB&OCglFeI(s[5uQH86F\M+qc3rl(K<&13g*L,b(eRlG(NbGcjb
8Kj=TN[]A,a[m5'EP(6?;W<FD/(6h*]AO:K>Fn,rO12+1B1*r2=n-+t2E3B\N#/U@'[q-o.5O[
!;6=5@W5p[d]A#=[<cqlWaO0h'q&U8C"L:?FO\M+F:2TR,pdJ=f-3$RLE,c7XT_3a67\9Yl:-
gs,hf9pW@#+\@'S(\f82rlrHBnoD:Zn0TiUEX;Ltm)Xg>\W82q%;6u:IN,]AkTI=9`O+>9ri-
]AuP7lJIJ$BKr(/j#1`S:q.h)O?p=3;G-O(,rpO4YgY7<Y<Jo874jIo^"8e;HgK<gmP;:js]Ae
Q&:1VgXj-=VRZ473^N$f!Y&b@"/ne4=9W(`C@C0if(dLhK'44#@sgd'>0JPiA6A'+c&S!"aM
l;iCgF9K5_VS*IJ%$XD\*GX%t]A;QUgM72,5onUt^BoE9nc=h&g-kl(G&JbMlP<:U^&kHFU0_
"%RT$J,bm*p^#X5C]AdONS%5X*?:2lK<*KMR$[:(U[c(@-uht)=:e]A-P(Weu<1s<W[3o#_g@2
8;[)8BZ["lhSN\e.;<MB#(/q#\Q1.uWoC-rs+E@s,Qg#q52ST4G%"&6tC=,Z@9=8OPf'BPSB
ru9JdJB@XWKifs.N)\2,3j7UjV*1XWEFO\Y@p3')/g#4f\7m\A!Fl(J"G-OBmSX(t$%%4<c?
H*3<%Hq?oAln`I#J\SUiNTnZ%*b0Me^tl7]Ao\(n[$.AHO&#q"lS=LY=,>L(TbF2l]AuIR0ULa
:rQ31'_05a`TK@8n1G0O&]A$C!,&P/a*'m]AqhW>=PN0aA@/4m=5<<=^#R2F`O&hE=bV/YGFMM
AIe.]A8b'WE(=l!/:,50cfaH*bKR(^lV*pMUtr?U&m#oL<N)T4X*f0X79MT#=YsERT;c%Fh7J
N:pP%ig5X#\"B:a<nB_PsPD\NPCS6J;>J.\r4iNN+*^;1K6=;aUg@cK"r,lJ4D..0UJYQ\$!
-Yi%Qojkja*t4XI#2Nj,YE1uE9F8p^_A?F,r"Z,sP;@a/PVM'[o&_)pV1_sI/$qi,8-Y/QZ\
]Ar`8+eTA?%\h%9=0Ptn79lM*1M,qQ'+PW+C%F*a7:k&mV\:G"\`J,Lj`+<'Nf,_$-P/T92M1
<2fa"[RBl@2+,M=:(^EipC-dJOWk4?gb?^WmNlSfo&>j>;;4/L%PX3X]A#tCDj=E%V<i9'?Q8
kFN5P^t9=\03pM7--3X-M6Et["Ja)K<O*.@SO9h9)8dJ!3nf:8/HH&/ShV$YhB!/9TIJ(W8+
<,I*;4c#%40,`B56YJXpV@G%(Q>JmBZ'2+u>2H9su?J1MHmC_F?iX0aJ@_>_&8>5jYpFCED^
@-LDoYTk68RS6^.58"4!#?kpuNDGDRdc'>0?N.tR[1''o7%BslZm"r^i%@W<(Z0ASe+oL3V4
-6s]A+e95KW[&17,[(YU8N5"jkd9,=F]A\#`cR-EdB,bDbHLQ;O(86@BT43]A+-J9@,3&ObXOCb
DY(*aT@^JSm$5APG?hILCP=K<$^EV&9`bnp+#5-?kE()>*[Kk?S`Q1&InJ+UO=XF^UjSOW5`
FDlr,o)<JKQ[9M1N*XXdf6UrGXs=@q=q$9-n-uCDb#8(ATk!<n?=0?U)WMVfTHcg9Y(d0c=3
-TY,D*h,#;[.cLsb_3!4>K/S\nqmPKssHo*L%&;mC!mNTW.E=Ag;g,,.jdmP!c:TYEQfIKI8
IVhWr\/49-2Fe]AjY!*&@i[!=;gN7Lni2k+Q[4n3@q%LKFI2C&8=JJPDS'&]ATeL<QgF'LTaJi
6K,/Ol>-Z[BD_?3F\nJZP$LZr*1eL5Ts^lg>RiDVCtS@grIjPm^i^Rsi-]A*hPZ[QaaB(>*^=
12DiplI`[[&bK1-+2(iqg$T3g`:h#K1"]Ae\(^^ta#C)b4>e%/qf4^b[=I<,CC:Nt5/PHp987
,d`4]A685CJSM:5d>%#C[<EZ%A0Cf/2s5-:a5kJ$/O#@:=q_N>%31g_AO%c):TbXr:&"?BN2o
.O%q6hYV%0QdZXR6(,i.'1?PBWcGrf`,NDFc*fETI'[au1DV`k9c0PX;'quNeXMr$K^UZi6S
]Aqt!&X-qMp;Gkh/!bGD(1K3XoQsDi3JjP[\ogEr7._#eO^e\8.UgE"$CTENZp=O+[Vq&WIA*
@gN@UFGHH#+=G,&54TT&BLa4t!6r4%s87L-/)MJ?bbo<GYG9Q63-K6+psBnloG-OY\`&KtAA
p0di"sgJH0SOVa1bVb'1>qa2Y2p;ie2Xh7m,k/eOg%1R9p(=96oj&"P+]A6'a560^HE51OH]Ak
oLk+)5Ke[A4g6R1/ZTR<5(u_HCS8-(FGC#@Gc'@MtVu%%4CD]A[Ca[pV0<n=Tj!47CLW4flaZ
\&Nnagd;"KN[R_:kd-F%t^I\AP"]A4#nLM^JGm5$r.(dk=GcE.gY);f'sZ]A2pP@K4LPAmH'sI
WtT>sCY<Un&9_"Ie\9!e6cBFN7sUR1?m5&GE^1<'Z:;HW%Q/-RH-E[@nrcV$Y1LYQ+`0cf+Z
dg+U(Eg#LT^tfC(]A(BfPU#63gB<X*3+%Tj'K.a%1@CDGJTAJ-';TE;81j5SQ;!]Af%o4hb7l=
`8sY9nDM\^j"K5.^&jb?la8LC>e%\5;^^>0Z#/CJVeYjT3M60UC&4C.$=NXsT=O(=r96`leU
fg[GhmCFs<lLrD]A6V,DY;!49(oe%"NnCQ_^U0jF<<CWsQ<t@9qG_XY6$<\.5#bH^/6Pq03Ke
amNF)?qM\&kle,J4\3YLE[g'W40Ha?$#HHiYaE7*J^Gp&>EXiel*M+HoZ,@]A'DAbPEI.9&I3
DuBgNNV*6ck$6s?Jjt+N1l@VdhbL)&/8q']A&d%7c=8n*ChLGTD5^WEsJ%EMcf0c\&3BHi*9f
_ckZt>i%<@W-X`DRZ@._a`I&]AY.L.)PbMQL!0d(`DnOXu1J'L:7q0?6cr`h_!\u^^/W(e?h&
m\.:13Sl8-oE3*oRZ;EeLd5hrhKQQ8L[h1UX+1PN?d.fmEMm"!sLQ]AfnMo';C:/0%=q#6N9q
#TB#9pk`<FVK5ZO:`K4QfuunVnRRW!eDdP`&49c$`>LBBBO;Uns!/e!IQ#.(-76D3--LMrRe
bU>$-=+%_OljK!t#43^LIu3:,7Pn0\NCk`.q<"GE'BNTu+!@,&XK"7T`/WJS92"TL>D0U)kD
71k3CFbXM,o(B1i1n43%H0*Y;cL:k2;M?QapiNdb)A9:GnPabHJ%ToO@b@bq`fG<:._c=2&<
s2Qc+5NtLgO(;/=Q':eWC#[XO5j5Af,`\E)-emS6Wj$^lR*,f&paW;n\1lpo2/<GBjE3.;d[
pK8BY7/snTDMS(#oh*J7c/`j;1VGKWYo^l%UoTuB-7<kq<4VSL*"!P<HEQAUp2G1b%*p&UmR
)!<]Al/65bj*%`!D/>hV!%ir809<fu?a0ldF'QIhq2J8CIKbq+n=upLpue8Oj^eF7F`fTb,5O
J8:<KYL)q[0/^5GDg7&>Gmj<5u^i5J&(%W6"06WPX%aWNQIC%SuC<kp0d5m:s?SN4Hp!L3$S
MNTmc9_a8Wp(MJ(Q,.'IID^a$8"hq.<XFhtLes%,L0ASgn)t0urRd'Q(+bhJIEB=9L@_/l--
B$d8`AjcE5E/)q.SdtAb&!L8V!1,g9MNl"*hl$*F&/4T0Yq33;E*Ji;$B.VC;7)n:j]Ak?k&l
i[>=n8)u5Wr+=O)<m?e]A]A*0HF_?`G,lk\GQZa#73^F:oFqM:D@-REhk@&Q3X]A?DFg"M8@S>'
=%m)#<W`X&d7(`ZH:Uh^QH=p;"-\:+ZNXq"UQQSJE[ohgDUuqhuNbB\FF]AnLWfA^[Y?qcMT-
I;&BM`b-6pF\hl:3!\62f_F^hrfB+EGaIT9d6P":\amK!&.0nIZLW;I.c"=."r)$DY*fN9)J
qG+n;"QJM/FPoV!Ka;Gc<-'XN#%[PJ"<A2\-O#q_%8qFF"Ke,=!,+4W^df)#Q`<`/8-57M#2
jL11OL3O2'1\7W:'.$n4R6("E_Q!"sU[_g;;YUDS"5P,p8i).)Tj18(>BK/:pT-*FU_F$ct:
=kPeX/9V&Q._e'uf7QND?+\L[M-&l)RDPc8BT'GIB57+\1<N9<[1"7&f#^GjK*X_JnCMpLns
",WGe1d4q`Q,;,H$PBWBs!=:Pnpdm80RLKa%`OC=$Apad6/[q,m[rH$hSAL+_:q&#0PN1]AtG
Q<(UF\Z);%"_(d:pc'8$Do)j,ZQ+J5V&Ir`6<>/nSVb?QZ$eR^aWLHia.?<57[M2Y6IlH1'b
l!L)CL&;@ri`+2K0ApM%iqFn9Me%9ghi_!=<2Xo%#d0p`7VN;D2@NHiPU?):ge]AVBp$Ku?m4
'd6b6pOZ_abB547cqA('#49I\NC3[]A=bdeBHglCtc&`lKW0<I)&Y"Z9mR-D,ZX\?QufH#sW$
8b0)jdR@-e2m(rSB&sU?03^&/Jef1s5<]A<g&%)O5DDpPW22i?&X.7tNCaEJ>pg4R&Z1g_Uc'
%`sc/JKs+O08EIC2<QVNe;-Lj=j1oPT^Q7@2b0bGB6]A]A@;9Y#!;!VA?V?C>e!W/Ik'O<Ah^;
1+Rg;YcRC0--9jh7&e/%9U>KR4OCjGCXco!)l,T,V>8`;i8d2@QdrW'a3,qfh:+Z"Z:NEpl+
^Lb/=K%r23s6fQE2l7A95lWG3<REU>MdP02If~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</InnerWidget>
<BoundsAttr x="0" y="0" width="610" height="762"/>
</Widget>
<body class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report0"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1152000,723900,800100,723900,723900,723900,1257300,799200,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[3009900,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="0" s="0">
<O>
<![CDATA[静置链]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="Barcode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[条件属性1]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[row ()%2==0]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16711936"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[CopyOf条件属性1]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[row ()%2==0]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Scope val="1"/>
<Foreground color="-16711936"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="1"/>
</C>
<C c="0" r="6" rs="2" s="3">
<O>
<![CDATA[汇总:]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="6" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="1" leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="1" r="7" s="2">
<O t="DSColumn">
<Attributes dsName="静置链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.SummaryGrouper">
<FN>
<![CDATA[com.fr.data.util.function.CountFunction]]></FN>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
<WorkSheetAttr direction="1" start="1" oppoStart="2" end="1" oppoEnd="2" maxRowOrColumn="8"/>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="120"/>
<Background name="ColorBackground" color="-3342388"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="ColorBackground" color="-13210"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="NullBackground"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="96"/>
<Background name="NullBackground"/>
<Border/>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[m9=@.;eNO^g<;:R,#.qG.OqfIS=YaGM@Lg3a^]A2SFAUCa3l@Me<,PQb7L9WhZuLcHB[a42.(
<.raeT7U!sAmka\^)]A+9=bP&4eL/+HQs8&jgJK#9@U)hO`aim<!g@T0.LJJ)=S!GHLP@[C=1
@LjID77B[Mo/R.B2rbpZlE7qP[l-#AU[iYNU^re$=4,tptp?q;Emr&"N[p1^%FD+B<l'HbXW
NCp[@cr@Rs07s'VQP+6WI#:3httL)&CJmMi>jC,7+/@5PtsPln`b,L^1H[/j>B:rja4?*J,[
]AN2lN',P(gR<Mp3fTE'GM_YpaYrH(N5W>Me5UC7$o`*:o';]AiK3oiiaf-W*QJSC`e"pEH$YY
O64eL"G<tY2$o&%/`^$OQJOAr[r4=%V=;<<GPgMXOJ6SR":!$%.P))O&*'72Yj=I\PPod1[_
Sg+DP&!k.DekE=9^[]A,1_3J(T&S^rapP7d<e%IkW%5ceJa9Y:[-=jC1n0R=4fBf[Ve*`fa,p
X>ScAhT((LW[7/;U>pmJ;csk.JZEZ@fb'@_!nB@.\Li=rL9P1IJW.S/HnW<N;*a>'VhDNZP^
5HGXT5,:rJY+41hdqWLN+irtA+VaV-o.Kb1E7Jo[qNe%DeE(KBSZd\YTM]A,:Z%3K)A`fW8a>
U(#32FN>(buCit<uqcQ/h4#7$$5b;o#nbe#]A;04Y\5J2$DWhm;_4qD>Z?(ZVdp.Y<47#0-s#
`bS'_Xjn:B,cZ52X3b9`J5?]Ai//m_D9C&H8Y$<VsSuLjC,su"hQ^C+jn5/_8bnpO=F`s#cQZ
=eFH=7D>*?63<Ds<PKT@O%#8kL+kRJN(]AgN/>`lshmX&;dDN4E0),?)suVX'Vk.5-Ge<L7c&
sY6'1BFi>bV(tUaoT6ABA01LD5oq5C9>^b_C:/On#iBk&`>uBK:A@GmU/!WZ<(<c;d_sps3Q
QB_!@g!kk9Sd:\e-F#aqU!UeqBLV.%Eg9Zl?L!-ULPN!A9Mm$CR!(oQ[X-0Dh<]AdC\H^_X\d
#aMX'61qf)Q?7;u,VE4MEYj7O6k9_7ZBpa%a0\\[BkG0EWQYf$E#4to:H:mMms4kOY4q]AaZ0
(VPAT'YcVKL!r%c$N*lt`\23A%`LN\c17',9^ZsZk-("U6e1=u]A;8AG_%H#'"?4K=iaR0:i)
)5JO3Xhu?d`nj]A!g4+E@iUlRN4L4Void'6kp1'Vl%"%5'+dG/+a6%?I>isWk%elFAeSi!!7O
!9GVNThFBDA5JD9=Sd50Q;7gT':kc(.)&bZP\S_rH&=al?"4,m#0?+/2.8#[-*>W):MR9?m<
>4X5U[CoD*Nu?1%!k8r0bACKBDL1L!Ci'WT!d-mW&<Aj7./n"K(4<*f>;=K@]An-g@:_&-JOf
/pbkN;L'6=!qb7?op(1o#4>R`PR\pQa=?UBY:HP$'#XcG*lO8_@/5:VJBYc<[\NJ0dY',7l%
>IHmKAm)!J7]A+O5CJ-B>C!^SQ"%?JW]AU4a9(l)$8kI<Jp3NPd(l<(,97s,Mc'k3)Ob7_,IhD
pUP;/Mdrf\4U3_'LQb"oR@f$7ZqFb/Y]AAd0a*\[$Ag2au:<E!/GW<bkWtFPCRhT[-]AeS%Ki'
$@*TfZPfI_9Bk&c[dRJqN[L]A\1\(g]AIjR+AJpQT[[]Aq^(rkZK69QG\SM043*[]A/7Ft+Z.i2>
.%He9!L5]ApcN)p3Z1Bppe&B0N(oeCG4?GY]A2$n[.VNqf^\nldPO5JIrgs(SOE="\+X0>2PT@
r73h`A;+^aQ7a=EgW,38`kMTS@Dhfc&S_fGB)PjNRVEO[YO"HC(E9mto"gXG;PD5=S$*>B)s
@Ao6,)8^ZE)#a(co4)-SM"m;+]A**5]ARP2nG-Qm+TT3X&:*)YD6Wd5R<R;K6(I;:"a*-SK3;l
nRAVM_@RChOU^h42r6laI:6JW'DHApkUMScjeR1R*R?%r]A[7N8<t7Yp'nu(=m+dEI446p8OJ
0Y_GL7K>Sr&VV[GLKZn,rQo4@.Zg=%omY'1#P@'=.Y_;og7&%W=joP!+'6]AlND_(!YoWu%+V
NSdM*9R6<^o@7(+)mSRS[YT]A_^OQ6p5unJD'j.R<OG)f%IZ\*1T73YTS;-VGH-8MA!VoB1%u
h(4'^',7'-?5OBjgq'jNG(LIbC3loU_XMp/f=i1s!=H:N1R1$4f0"XQ)CNZDi)lg=[R]A*_&1
)#Mmk(Judh6c^$AIh18/1Qeu(ACI\sR-j6M=rhW\P>SVJAnB\pEh=TP;rE&l2O`'CE&>`+N&
]At76563DqT10t]ABPo,2klrf\hmTG9a?`eYK[p_h-I9blAXGlrPf'<r.Od/Qt7SnD@S"_(2Oi
:rWQT<H#]AOLhPU`QLQM&-!06XIE&g4Kh7,A2&%Bm1"b2E3JQF29gi8mq;[;0`DjbP:p89ECq
>#r:(EjnI914F\Y/6ockP!HA;2M`c=YEXE@Tpo,C_Ms`=1;-e[rXgC%fMFKQINQfZ+Ek>>m%
S!R;CF>V`6!NK,D:.bUL/1?Joso?&2\E&gi@MHUf$__=VDqdMd.2GRG$<OR(jJ2ZiNVG9'&]A
$&=U4N"\e\4q_%cS;Cp!K=]AOCJSnW>?G<hBh02.`mGB6Qp,*Qs?=78Oo]A@`5WZ+&h\r[VI$4
kaM'1+Y4j8V#H=fKqCnts"[["'BQ0QLar:l+t$;N"nYI5-6?EJn.8=u/u?VR;VRa"00'E!KU
p@q3,KW,hpKp3-![:m@2,`bqM/R.C3R0pJk5!pCn`k;A`a@,uNZ!o\!"mP2uU)?,Fo0p2)<m
[gqEgSqC_9^W7OM17/0TsB>MbDtJnHl=3FQRBR^VLM\@LFP,SU^1bQ2=SdZ6s]AZuF4t[K\]AG
W95FaU6j"*O`+nDku>b=KHSi_B4$pf5f(s3M30RpYb)pDbar"RY!aDD>sE&maklTbd5!adG(
Y0!ft2`I):"%[<2SK)dr71k9P82X/PZ#MNeFm,e8#7qje4?";hW^n.LoVG)dj&YYj20[3Gq^
"B1ComjW/Om7Fa*1r:\1r^l%-;:VN$)D8+"j_>gMYj`qer_-&pg)/aX&^aF`;*%j'(dDbc90
CZ=jk7R&R6d0i'D6U"'A]A&W*p_)j23L@W_0W=PTB#+S]A/M6+?ZW1kX.:Q+rKN!%4JZ^:Ar*5
cma?D!Y-Fp2`5F+.?6E1LbkZVR0X$0c7;Z'$e=OK4$W`5eXsCr=;@fNjPj7Cd`bn,`TrTl:1
O6,R6Muk-j3nJF,GN#a\@_.JnN\lJVcG^:@D^Z'Zmb&ZAZuJ15*PgHt;:@1`7M3sec%SnB:O
26H(X@fIm&&as49a:dS(BL?O>7M*FI4h!C4Or?f3#J)'[=Es\kMcLO$o_ZN(k`N5i&R'?k$g
BI@?*>jnLC;F+7Rp\SXE@DiM)<F#.qI8<%9ZLt4UV0ZA-F\c;(bUG1e1((7<^RsUqR5uY,In
#(WO@3*B,_<IZNXa>Y>pK-]A,i)gQ!G=Np+HiX'!-Z6kjGA@i:K#o7>Ag1"htIAbdpJPcgn8]A
C',"$_6fj:LOoNAHf&%iTd0bh^s=O848]A+:Tfb0H&`"L-Lo@s#t3m7cRm?[#cUsKLd]AlNk92
%4]ATS6P4h7ESXOU>rV:+40654[VLc1A6FL9G?6<Pq$CPE@!]AYbor=^"u\()?knQKu8o?)(j'
]Ap3e.OeVd2:<GS+oR(HtkZqu<EW>n>i%OSe!>`Jg/?4a?R_FLL$_)6<Db!`C.+pm?=EPl0c6
98XgPdd?Kl^C_M31*ledOPgYT8Zf2"'fQCo&R[Jm8WDW);rUHR%-gAs4E,IhjS@?c;1*CaC#
"1t(-s6,,NOOlFGlftOZP0u#aK/-7lA%95u\-&)X;oRQ</*1&:!=^=q/%e$\10G0%;)g)K:.
QJ%5P^m;3M*Jn5\#n.BDU8W+aDk@b_@"^'o"\%O1G=?NM%$0rFTSpZ*)+X=##_7sKo]A8dSP,
4?J1=WER=J8-:j.F/AFouh91+b%qZ0Zf7O`j8]Ad%K!>tS\$V?=?gdWd6@E--6FrL=lUD=h]A#
$RUhp.MJ"o*R$fEi;O;I-aYjg88k@J=sCbj!EFR]AY[H?e5cX6-b6pj?X$QEHg-AG_@ppT1jD
L+8l6-]ArE<63=Ql&rk%fLVV(pjVLNW)d<#o.390Y%#Z%I1Hd##s\,:]AoSj6hpY9!b0T@LC#D
+0"HM[BE'OQR^;<.LHnBql\k!mIL"\X#La@"*ENX]AmrSFj-#>9qePJ(%$<13US.l'6n:3Fp?
\'9M%hp1)j%nj7VbDnCnYYRD?+=\=1`#]A"c8P&sV<cHdP2[M=pHs;V*G8af0PNQiJ<"K>^,^
W:FqNK:nh3H-B:]Ah_)q/0'h>f'O5cl*<^r+hi>L$'"K(coD&SKO8q*u']AO+tm!ZFrtE,YpHP
&1T(dBduNcHs-`8=s@Xd.Nb[M,K8Ip6rF@cWFSoXMLl>'m42"!!'\<:A7Zqto.bR%=C!%\ks
hf+7?S/ph*`DiCL;T7%Xq!)WrQnS,\f.7;IU_o&(NS.2*/W1RL`T/h(&+Ge,oWB7/jh`4UmW
@"'tEHiq=^nFhS-@%\GH@9E5.up/.c*Jml:HdM>Y]A7N+H\#2&Q?cu/Qs"_-'=1.,q)R[3dKN
-G_[1(M>#!gJ>oLu-F!kYB<;'a^']A_RQbR$[feA"]A]A@NecVqS^/HM6=6>jQ-^`dl(V\]A3n3<
RE:U3`S"s"bUV%Q&\mp?0`7!+sU5\FcDRK[\:m3B6<&q=M!1l#lSf`o<5Q`;0FO:NERNPm!W
8aP;^=LV5q4Dh?ZTMXO2P'o`5ODY;YW.VRM`,jn#]A^e^Sh'6j_4hq8jRW(CCO7#'SX,2Uspj
J#69o"XTA$I[4h(p7LRC&sIj:b?AE!9'mT?sKe?!cf_[K<-1!g`$"aYMmN/ia>OjJIp.g-)\
PC^Fb)ZcLqBA#CRfL)p*1a#?b%VeRLllQtjSL.!W?P`ag%`:!R;Y!KX5eoT/Im]Au0urP6.?=
]AlEIZ3o86Rp.Cd/8/[EXXc!/j'kHXO&E(t.J"/7&a^q[Emoqq>apG6A,"gJMWo(/NHI''8!.
o+/H6+,3L!u`SS`@7V=X&rIDu,]A@R-TSpni?i`aY]AT\aJ>r8=/%Z/\tM;R#dk7J78EJ'kj@C
,sEpjbe(.kn-eXpO(irK&u-NY=kBVu7L[A7MOOg"3h,6=BEmIHWN3RTJ/Wm[0RU2=BQqJGS'
f*0Z!!dV+;SW[e/-05@mNs(DZ.;[GZRIi^p6ri$QiKs;?R[ROPeQ%ntT:-`l(P@hNY5X@/N\
<9g1><Y(.u@(I-N=!,%!e@e9b'bjEH4;i$(:a2+RlO%oBJXt;\TXB[kUgM^hOM6O!8IqsJD?
,)Q0WZJmBL=lD@<cG$on0;a`UlUD*$abCmT@TP!$/^G>eJDJGrM.*>(`3QLeu[Wj%q6;K8Ks
,J)V9+g-+l(Z,Yqs2gJ96@KEOf7V:dRbd<j1pEFX]A6Q+(WJ8X`ipLKls.J*K\"@mPYA,W]AP;
'#,ffDtnr8j-JJ2!W-r&1ch2YNKT/b*AY'Xeq(roVR4Y)g!^<[]ABBG!]An,kRGg^n1rlKJ?hh
:>/f&2-O*^!*_QV/#bHl(f*10b!0a=9fF@;<?td/OT*5YtQd3Pl-9:F!KSXThr\h;:?)@%l5
56AdmMPJEUE$1@q8l7MFOI:VH_AEua+o`>l+P1]AoPo7%NudsV-ZLlC:I)0R%fY-aui(MKD;H
@k:hqA>S\;3\:a.nZa<2R;M/Ydb5Ai8Ur7<t*6jTr)2SN211K39&b\De+AnSf2gn!j+44&TM
AE>J$25)j@ihS)u\3eFpNo.Jc9@kieWIA!RDPGCHMNfbksQ_q]A[i6^RD>A+[b!_/o0QkuDR6
Vfa>L)Q[g&>4Mi`QJ1l+\?8q8aeQ<u5M1sN@3[&Zj&o<\BWPk4KS<<`1C:iD=5.1l\:KEl5I
/^QX!s?Q4X+.i3n3Qc\_h4Y*/F]AcD<<OON.c6`7no3a+Qab'XhJ#h#E&]AJ8(\nkh3'm+O7WK
Oel#,D#b,1/HfO!m-kEgggQ4Ysr!Rp0A<JV>gY/XjdleNb&Pl+t#S7]AD/+.AAp.h2[7Wl!J^
;OA3OHP>cFGnsnJs@ct]A05@$]A"!2m,nQ8ViB3RDd5FYG]AsWql2GJu<Ng:(AOL!krI.MgrdFJ
tCo`E5[]AM39,rJgNY`#W6=qYi"`+1$T=%\cL^/T\Q&TK6Z(kf&'P*?1WJDofKNgGjEO4EXR&
3$HU4V6mQ16XT3`DsDF?B^46(an]AikpO]A@WK+=KbH*m8jR(8`*/UgB2%V5rV3l63qZ&d[#\?
>/J#K\d:j/8BS>ejnAneTgbR$tB$U0(79FXI:`J?5Up02G^[mTbfi$tX)?:LMG%KpqW"@Pkp
a+;o:URW$u2OJ$i%X$/:BHSB(=RU.!:MqRpT`&'a8]A-l`5G#DKdiq@oM[kY]A9j^/SdK-ilP;
p>gubgY;:NhF`\OR`OjSk[]A%cV!K\=du\5O%m#?5H%7:aA?pNl/^9,M!SHsm$j"`#_gF.'!n
)1O\a*<Qu'mf\HNO.OriVRNJ%;(-4]Ac>j0qkX7M.bLD%<o/0'@_e00:$IT/qII0Pig4IrYWZ
`a355Kh)2.:^#<W(s5gq>\&l@Yk0c*S'"pnQ17>#%4VrLLSU%\?&7bW\>PGCY\pQT:GX>O1u
;<$T'j;6T7K>>5h6V)ac\s6gn3-bmqVSWqrpPjTEMp07CI71ED[lL+9U*gU6c:K"\c?L#U&@
LTVMuFC1ej.#a(d$hc@7r<":&dj=?G[,e&[/MD$p8q3Sn@eoKXDg5hXeU%3\$4:FA>)]AV#*Z
[C7#."@L`Gn;0hhu<s+j2^4Ckm7+abucGQSELGcc#Y[f_tXVK+;eAs"f$hs`oI/D@/s:*88I
mh%&WX4CI^LgKK;`h(^F&]A!u*W?H,Xi38NcX;>hck_-YR[oA)enY4cScL5I#%OWi"HCcHHeP
=VCY&EN&K[DqZumgrJOuI1TI%_P&IIE%+C".WioGk>HX_(<b7Z9G]AS78q@bG=D>;CS^2Y2)[
H-;&ri=jALJ!!gOX_`j\IN"$0+6tj!+FZcr7!_eM3,tIW\C[IU37L\M%)F"6ck`H&q6U(?bT
\`X!`99sXBUrO4:=SPpU:OntUR,Gq6Fq`d?mVX=h?F.lM'/_;3+H7V;a%VMr9o+DMi"BY#"<
HoFg4iEJ@QB1l4@Sh]A.%'Z;.Y'mY.Y4!h7BXTl>gs+M"[`UcdPM'dlSb9iBSQO4!.fLf-<lj
:L^2h+TWp"Xh+`.K,R#%s(C^qNl;$PAM80-PDl46,s_TJ>jR_-gT6of0@%Rt[R,*?D/e5>O,
mX(t^+,:Pa7Oi$oZI;`r2`e.Eo>m7C+gU(5-Ld-En8?>VWe%Q!g=bHX1DQ3<#_tH>K0ML1'F
K,RPMg'2q9eBM:^k<'B7/ENYVP(lZ9rO57@\FFpgY3S.[&Xu.+sp%i<5!\pB-;719d_^_P:N
q.1gFYJ#MploV\$upB;%)p7ij64b4jeL7&HSTr)]Abn9>c[Pb4-YJ?\LsDG*]A_![UOXGShBRL
8(1mJPU):=C06JC'OPoDFo0u*!IteZgTLfNpK*T]A%aj@$VaI"5s<R#g8@ogVjug+/-OF[3\-
mfPl`F-drhX.DAXe_HFroD-s[Bc2&Bfm.#K!Z0*'UC2Mr"KNG$MP5;P:G*4QZ[Lf!4&^jp?@
bN(^26"Xdi#s(E+<0S:N$ACR3TA:2I%&'En$]Aq)kd$C&]AKd>MO=$b(P!!!/SXA<MA]Aql^JJ*
=5cs62j7]A!IQ*3*HaLqICYkgBW<k>U[5P#;),>BIhU]A8B@V3d`'Tt/E3uBn<:cq+s^rF=j]A7
I/.mcti;nOC]Ad6^_Kd(b,roROAE)M;<96;6UPn3qo9J@e;>1S8!B/2>8*=LCf!.>lCR/h4AJ
2C3\Y:bP@qAJOE(aN\K'76`U6Du)rl;&3dNcH8_G*$fD\0F*,XZAFPi")@2"uRdHKJ5aUCK9
Q=&@(QS\jLt23t!ds#O:!-%CDR:KA\+875L<IhI(RELUiGBPs`7(NJB5O>AR3:58B'C6fIr(
(NJOC6U?7ooq)h9=>G[[q_uQ<K`[J=b5L!l.]ABC1:D$+jI/^*XhpMIRo)>B]A1j$k6%a6FiZP
M(ZaLCrY>L^Dcp-Uj&H:l<4n4BHX4rKmEqrUY%o-M![r#>L/jGuoe-k/2MGaLQr$h_7\!"c(
qkF8-!(=1k:4aa`.b0)li@J\>cTG[B&WFL5'ii]A'fCF>,o"9,upM0cYnS_`r<"T~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</body>
</InnerWidget>
<BoundsAttr x="0" y="0" width="610" height="762"/>
</Widget>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.container.WTitleLayout">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<LCAttr vgap="0" hgap="0" compInterval="0"/>
<Widget class="com.fr.form.ui.container.WAbsoluteLayout$BoundsWidget">
<InnerWidget class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1152000,723900,792000,723900,799200,799200,799200,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[1104900,2019300,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="0" s="0">
<O>
<![CDATA[储存链]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="BinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="1"/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="Barcode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Result>
<![CDATA[=$$$]]></Result>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "Red"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "White"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Blue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "Blue"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "Gray"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-8355712"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Silver]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "Silver"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-2631719"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor, BarCode = B3) = "LightBlue"]]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-10053121"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
<C c="1" r="4" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037043]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037323]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Blue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037073]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037067]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-6908266"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Silver]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037061]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-2631719"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.ObjectCondition">
<Compare op="0">
<O>
<![CDATA[12037055]]></O>
</Compare>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-10053121"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="1" leftParentDefault="false" upParentDefault="false" order="1">
<SortFormula>
<![CDATA[B5]]></SortFormula>
</Expand>
</C>
<C c="1" r="5" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="BriefDesc"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="0"/>
</C>
<C c="1" r="6" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.SummaryGrouper">
<FN>
<![CDATA[com.fr.data.util.function.CountFunction]]></FN>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand leftParentDefault="false"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="120"/>
<Background name="ColorBackground" color="-3342388"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="72"/>
<Background name="ColorBackground" color="-13210"/>
<Border>
<Top style="1" color="-16777216"/>
<Bottom style="1" color="-16777216"/>
<Left style="1" color="-16777216"/>
<Right style="1" color="-16777216"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="NullBackground"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[m94j=PP<aRlW2X5WSb:jd&Ol^kM0)>o73?pbr%87P"euB"NV:2BLKcUJO%:;YKCYaAo44C+`
/X)W$+bG69(e[-)D2_!#$Y(;'JC6j?NtWOMgf^d7`6ldci[Al^I_Pf>[X$^VfZTTDQ1fkC&E
i+X(a^&"!35hRn+A2u`g$/bA,<J=\^g]A.8@",4qM.T,`L0RhlmRn]Aftj.CX%sFl?a![^+4K$
ECBjFMGE3qP&0*V\O0qD`Vd;^130&,4T8W_OE".k$?kg[\lTMG6iZilAE&8rlHfEdS53tDMq
c"&T@^"WpfknT47d.Dsc>e$r1t?R,f$oHQ$=O>#U7"W6c5]A-MN>TDQV:)O'L^cX<gr`2q(Qt
HC8%C6A4Y.#MX*<\)#ibXVsbW8"f)1Z3FRgdCEINHIH^IE9"R=`q8,A=#!Pl>S9!gGB9)tpM
a`REt>I'UO(7[T^H,u&iUZPrabHF%/2)/(`e%i($XH7`O_2g@'h"KEUEb%[H.<A\0$WPot?;
1.aR\`?rT/cmeocnnBAd9<-^h,Pr6Mb;;TN#C)Knk2KrjkI9hc<'<0TnSJkoq%h[<G$WpBX'
s^/"Bk.jPaIQ81f2s#Ma]A%5FQ*?`>l*.Dk9+9etknrM=/-LrP>1P)R5KE-Pf"t^Q.fT)MR(J
[8@rP$b&$Z>hAOr#IDE"X8V%_b-+E^RKrE)CL$ZW+b4h^AkUd"ZfPh!bce"P#:hkJ`<Lj@>q
E>Uh46[1c+Z1dA-o:/S<U@tSba,p.;BcHLTq5:J2Tn?:-m\NW.0Gn[PG?<pE=ar[7'XR=umL
(0a7(K-V%Pp`8nhslF3(*+:hY/c$$/As8QV'_f"BdE\Y$.;S+,2D?%Z8CkM[I/F_r1'P$dm`
@ja(SDn8UVZ%<>$MhiOpUAm$HR[WQ3>GV]AY0(1qDV.8p3)JtcqcntV]AR4j0g/PnWSq"&l6P9
t4<'P]AbLeg-<\.gZht.q2+_H`LYdd)cGDBVo.JO)ga=cDB"$jUO5Tj#-Z5m^%JjRb^!H_;nu
b\$2l^+<Ks03Eg#,.Ls+"Y2!K,2F;iAkeA%Thh!Ga@MbaZ'XHUff9/:9Uok-)H3YON[qkd!H
GZRb3-SApY#HQ'Ni1Mu>$D_1D3uGo*AT#Q&GMqSNFcmZ126n<0_j\dro2mVu.,B'QO(!0aaQ
&8,oC?brb1AD%NRE4l1AS6"Dg#KYbg2?hC5:j0WH+E^2<NSM,m6$hM1F&%/_a@Y-1dU_E>(=
>Lu2Y5*$0PN'\lgMJ_Ji$V[Q0.nhAh/NA:0k,'*dqOi/?]A6%:dY0IoTO=)nL@D6ViV+]Afd4%
-nN:DZ-4>LKmTmgu[o%V[uU9;rsBaMF1&T+Et<n,0RKnVKPt[X(fUU%8TF$>%pL7=U/g(Aq'
+f@H^Z/<EcANs#!FCe=-tImu^9mgs5:/>HgWt0Lm2+gcIsGZX)sJDbTrkKCg-,cDe4-Mi=ef
Q"Vnk4`j1fEK.>=i%C-_]AI$0//.P*.9idb>+He>m(:]A6`qLr"%,>BRn\'A#l0!LbfQX?>k'P
TCR)f24G[c:g)Ma\ODgbE58BXCKD:=JU),'qs9*#oL+V>T:+%iEDdn'@^f)Q*o^9'tqFAHSW
k6Yt:KmWskWHo]AQGV4kCu=?e^?^bpOE-_sfH"h$qA\,r45Jts<aDt#r$]A0AsCqk>bi!YOH@8
8\_jmLL^Y;./^B&-Y'-/9trWDd?"FL@HLWTTV:KR(B\gr6n?n__=869d<5!EcF;[1JLWnSc.
/eUX>Oqn(O&1+'&PakWsns#FJjR_E,?$6QVjL%uS,FgD4*36/[fg.LnEkluGipQYU]A0!mVns
l-9CKHeoK-V^l.XI]AR[ulhdFuH2^!oWlH".6gp+K88#@,`kpusf-_*NAdl/VRSrk+kg8._b@
HB"'SM@)+b]A/SR3@-M';i/1jduNK?[sB1<Ef2Kg&.8^cKT&<:tRY+`O#dd\&X6!$ACQ&X=/9
VM*G#d`,9L49s)iS?=OO\?3<mbAIokJZYouA`C@Mjb1duub&q#$P/rSba3?atoQI>L01^%=Z
`t:PXdBubk3cU:FcZ3pgd%WMN%Bm%?T=P23FfNq*$`EGeY-YKU#(O&I`n=pEiatF>3_J\9IW
)F]A+1gdU6*-#+SEZpm-c[Q8,%83;REg^=N**4JLWS`]A]Abq95#)XAaK0jDT%P!XL:%FjrWM1b
ijLqe]As#5uI.,)c'`huTMEM![m7n>,AX`aUG2!bjJV>^_@>&ptHgZO10dad,='A7+\nj%<O0
$A;E>hiV&i5@+\g+0E>(erk,gE;;0s7sS44d9aRE_B^=brh!APh(D#%TEi\V=4:T+\.6a6?G
]Ar/cN!SQ'ke?lj)D;I?HV'2&r;Q7>,crT#Id7$E!W?:'om03O)ddR;]AL;Mbg:$K0pT_S&<T-
p/?l_i[ms%S&K;>bRsXV%Ve[jm;bkUZR'(ZZknX`SSp>D.?]A$=igiBot?7=,PmspAuXp6]A-m
oB'j:nI05.b0VqnrVFc&O!r\HMr`S@iHGsGoPeppBojFEN3@g7K>"QJG**P`oXSUB!!&r0)e
[Yls8?84<1n!_4#Z71JED?gGZDbsmM$!NJ22:H`B*JUF9i!$QoV6=::L:!q(\\uO=iDEqUV-
Y#_k#RsH^Rff<.W3T&HPJq6/o.MmRP]Ag%=qJY]A<bdS="1#UU>ZKh)^,E)='O<2NX8PCNX="=
*DRaT+.p/OSX;IO(e!8<7#\06`Nms9*mQ9GU;Ek`.b(k!QrBW+u/)BONK7u9'qL!nDBb;_Sa
*M4!TC/gs+l7#8<!@jg,/;2<&C5HpI$tm*s.Ufr:%&#u`;##O$u:EeH2#S_IKjfAn@"2i`ET
2`L$JtCX/YXqYNsc=?t`l"MW@"U0+Nti>K3mnhk+dgJRb,E0#m'n]A2^NGG:*=1c2C)ci5cKA
8G5DmQdRS,`MH]A9miq#?mFj'r$u;V^^=o*"1gBuD%k=t%9M9A@bu!5Y/FTLoH8c7\2Aj\<Il
n#.@o:o4c&1=RD:PPp`?MbF*_qtRn6W3BqQk:69+7j`LRS9*=<1s[kC"cmRe-6ESUXg^UGdF
V@R,,!h<r5Wi`"\aA%JakeqXI_'o^H1\d=FC!9[D6YD'+]A\If=_#2udkNW&qsPWM;^\hL"(B
\DBM@pRZh>'6`R4WYcsnL@u@>^i1a>Ndc!>MQB_MZKo%>3X;s]A3iMba1rhOZ`lJR6ru^!<4'
afk_]AEnX=T&Ek^O*$e8_:H<djpg5JNjQSc\/\9^dOKJ;Eol2.@jupRZUs6$FoOSgJ5RHe/Sc
d(MRUNp^4jN4TG#)c/q*m4:gHW/0(%ZP$-=3Mt"'U#E[_XJ65?2CA^(bI^"ecck'fR"M/.hl
(>D7P#HX.Ujr;+fa.gM</6gN59SLPGuDZA[%UXWR4+*8j*2j>Cd,p*MsWKHdu@0k+_]A!>Y9&
`;,Wg%S@%Fg_Gt%!jV7q$>ho*fh2uOXNkXB'CA/-+]AhI0.7QE'T5mM;C`TE_lQA6"-X.8$8M
8eE!,/c"KY_9'6o-n5I!P:p[XTV$I.-mi-c@lolgeld`O?I:M3[2V;Csgn[(aJHpYBuM#"O<
QMc2$-pO=U=[lSrUaraV%&kQ.O'A]AQ[o!T_GO=e,i[T'FRp"@sB]A^!7,`QLe3HJ_S\$(T+sg
+EdhK;%:qcYm'Peg'^6i@GRm<]AXYV&\Qf3Yj2cfia3\[j0)+sbWJ1@Bm-\u`g3\:F@fRRRQ;
s=DgNh/KhLGI-*a"YJ\Yi5NA]AQk5fEp7/:Jp!6mZ4%Irp91IHXNn_Rl;r!8mFMp']A_R&EL)@
/]A=,`Orr+FSc#I`r-@LD1UceJ*OShm<+,hNH[Z\kP`MV/^\DDsuKd&fpH,#lM\-SN`:KG$$W
<Tlnp)W:.']A(idDLDA4mih[RY:ap:<i#KoFaaBp_gWn[6i9(O::iR4\J)d,DOJ!b%\g>U)Vo
kme]A3=XB&,Z#f>^V/O[V;*=bPkUp5if>h=q#,pNHG?`'^<K1!ZdeTqR'4QKVL"D6KAtlBC'<
GDnhX.$7`rpc?&!,%7PYO?V)!Wk;)XM[b5/NA7]Ao(9-522joq5WbIJa!i/:`Te's0SEoANLU
tuO]ADXA5Q3o%SI]AUJXXMYjGP_((7gCfL#(pZhtTK62X+&H):0(RTo$7@=-A[;=EScZ0#2T<:
a6)"FD1M'G78RX_Eh_9(=(YCK22m14E)8-9/C;>f>L3ZhH+-"jZ&$p;d0gsL#pKdX)l#47(P
m_@"($s$#\g'Od5t$9PSD=?XXCu:h9Cq/gWqTbN7##p2hklO0c!b:!Ti8>eKrSZ\2LGq#WPa
?eYPOp>HYK`#V!0N@T%[!A;!D,cBiD4^3N9sf4+RMC8IhZ?.7.HB%=q>9#'<R!32_IEFQ\O8
MhQ-E/WgJW3,98V2$'RgVGM0K]A'X>ScYPN6%(Y3HZ3MXG(=D**]ANe$=TLj!?AG0k%obsq,IO
g7.S]AKc=U\]AQ,d7_47rrTaM>qcr6/6%=3B?R)r,K;TnMUn%XomaG"3OW-7'hmKZ)t_=*#?@"
8C.CtLjH6HaFM`:Q/=IG),\DZk!,%H\4>a3%a"53TfQfef]AWgE(@%pZtZ,G%jo$L^`?1b,A2
ZM(f^oIu4"sBc$7)hug2cP#-3p$;=UrLDD>ccBaA(-m%650L0*n&sa??$*F53*OLV,V_W9+n
usmqB508I4UCn1H$4V\f?M&nbDsqCI53lKOkm0Hchb-@>#gho--)Sj;N#E3!L"9pBI2li!3]A
W5Q=*hbR-T]AUi:o1gIh32O\pn=9N%;0J=^ddGWcNq?%?T.m:9WjK3pu6R=<=ckdps8sI[o$j
P\>O*0uAWn$Ubc)8]AcG\9+eLo%b??`!^]A0ik;OAUOh%KTE;%gbTY2,WV%JDHRE[bLB_5SFl*
>F(/^lesd:Dp!MW,lm!.a;<jb#5\86%[Hc_J]A\W@MLo\ZXJX]A4PT%X!3>:Kfn-"Iol4MU)E&
e;t=2cdMcT2i\M"mq@>_5%Sb5?b:eH%*e/96]A!o+#/B\Uu&0VeuM@+l`s*u<U9<JaJTJ;bD-
FjB$aR<XrnZL,C>S?\<NaRlMFIoj)[DbVK?5Tl*QcOFVC7I$9\Bq"M_U;/pVR5H*RENCa^3U
.$WYXqZRV,5u/E4V$(Xt?ssTmn+2o;I?3Y57NE_RgbGH&X;_dK,-69",)+HFR8u1TYG24aBS
Pb\W,MCp<\(V,c$;8+@U8%s<n?@4(b21$)K`IBaWU!nBcb9\jGi#*0+M/"<&fecd&&-h,8h_
Z;u3h]A\DBOiC$*DOd:d=4Om8kN[Eh[1p#j!CH72NQ^c(pm1kX+/CO9jP_j'XGl's`FTA*]A`r
AO`FZ##([E-_3<Y6,kf-BV11;;Jj%#u1.BF<;*@e\W*HY<9!?c:[DG?ZIQ4Y2d$)n"nIt,.B
r)Si2iG*1ID**QDghS0%.%CqI-:fZh%Qp9JF(=%`'DrY;MP_)fVl??Ubc+'%R2jq7gV+&SjF
[d1m<bZ4H[VUnktA7c&TD;t_9Gi4>rE5d>^k2PUL$_[V+!10@I"j>j7-[F>#&8[qCQBs):QQ
W+&.ij/$=?k:_fC!iodaYs)28!QY3V]A8`LZI]AaLi/\;KE"(OTNCur0Q]A9L[Ns,03V0Tp"Z9^
tJCgNqM:]ANQ2AG.S=SsTnr]A";/s&`Wh5<Ch"YbCQUqkuKGLXML0s5R/2#F7\Ccpa\`GLB+4A
Bgs$kU(?a@#=!!qdlS"J450-A.?&O-YJHhE>N1*ACBat^/VOS'[IZVM,Td6Q/=dP1m1Ru.fj
GM7-^7"dEnM.a$Nma#&M9JX;:.)4iu:O,LZ-=KMi4[h>J<#:BuT0ko8@D>Q]AN'=8K69-%31C
.)Hu);X_ceJpW9TGO(8;6B_7KfmndS[c11E]A99ZE!;2FdY2#/?\2]ABN>diXcfkhj#FM25t4J
fb1I^fd7MW&^Y,&U^Xc$@mr`[,\#`r%,Chh(^_6W@[@U6[B7)3hmp.OP<.q$r%epJg`0!DFr
(Z%>j7:-]A&p2:p;)!$-'&gs[h/_AMS7oe<<h5+45K"l#>H6c;/)'2L&(O?jjk1!b4=:K$<--
_gC*Y)@q[>0rtt9?N@mFq?6EENsK(0@@U&P_n>Y<)Sh+oOI.6A>FT<7+B-WT\\.^'Gh)BhLf
hE6GOTFU;:K-I.kZrM$VRIrlb97<NfT+3s,EQKu6t`:?F/Y&n)/R"i9E(/9"=Wp=3LFP$qW$
3rVKd'!Tes(QNs'eAFSuP2dg4?pW6N,PCV*E%URq2BHCjBOqO@9)Mq14Jg\t[0oU#@ZLO>c[
jWtaU@X%19_.f1u_C=rXq\f)O1-u0N::f)e:.$kj#,%Vh<QN&*'c=RKa[b_U(3$pX!T?qAGo
&W'sB/2Geh+AH(A"mZ21"^C>3(>e>*1$t@/\"SgIiT<*V<q^#?t[,*BsoAUqK<'Bcg+T9]AXh
V!E0k5:.^M,$44@Ls-t29*,1@A0eb!eRmm&1IonJHY492)M.J)l%HJ$7;'hLOJSWrlm&`0F^
TKHjKdJgL+\`%/Ced$tOJ+VUc0@aIOFd_;-n%(m%NfSDU3Y7J9"_bVBsJ/=7oJGYT&NN1>MA
G\Dg^`%Z:6#,&tp622"]An_A\FMO*9,rQ+9[ZALJX!S_[h!N6F'=2IC#6urI5XVdiUYVjesG[
Tpf&Ot6lX%D7#]A/VoTrJVZ!&&2;eh1s$#j.8\BD4L]AlPPLL$L6(T7&452'/'=l[)e$SH1r*k
+<+XUR>>UR$rR4VF^iTQZbX;S#%)1\;jnm7jh4XKrfpF2e+-O,<4:"fL4'M*KTosq$75,C0j
qg'RJ<b.1[ous:R^*V)\u&W@L&GX<V#K,lc:O(0Z*.*E'YXg418hFUDWjce%j^q;]A:MtQ([V
,VEP<#Q>D&h$.otlK!5m#J/OQ+jVa5Q&FtR4BQdX?5kNnn/6shn:)O6/QcZ/OE`eh'\.^,-"
GPe$I[Od<F.<"hok[WE/JIb(TM$DjkaSu-GF:Rdb!^,*+il?i>r[(N''/%F58<psd]AFt@(i1
_D-5LO/(pJli0W"/bN'/DM>(8t$p\V*D-01Q(*Qm)@a,%aB]AcI?4m5MEh..<E,IiY1T^#!QT
!mQ0`p*,p1M%[);I,h<p#;OWYO)_7C/G_b@IY.ZS/q)$J5m)>T*/kYdk_r0cHL2OPPNl^^0:
Z[UIa*7Ja/O%OU$fhCm$'Jl2e5B*6%&B2RQli^8"j!gl5i<,7Zd0Ti)-o=NA&[4>SmHBg^&K
Zuq.EA(_IiD)fm0mci=L8YGb"X0M?MHu+)gKK9u!J]AF,&t?!0>Uap$7^lFE!@nglQY6)krBE
hhK4m2TB1__g_SAP3frYjgt$^LLT)E/k;?ECbd2=<m]A4dp!^$(E33m2.r4;8$Lm"R7\O;=<_
;*.Me0V*jlU`DX2//FH%a@iVgZ,%P,)p2J4id]Ak/]A(2>s;7@]A+KPEOkrAVgj!i\oWo-tn7MX
q5QCEV!<~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</InnerWidget>
<BoundsAttr x="610" y="0" width="665" height="762"/>
</Widget>
<body class="com.fr.form.ui.ElementCaseEditor">
<WidgetName name="report1"/>
<WidgetAttr description="">
<PrivilegeControl/>
</WidgetAttr>
<Margin top="0" left="0" bottom="0" right="0"/>
<Border>
<border style="0" color="-723724" borderRadius="0" type="0" borderStyle="0"/>
<WidgetTitle>
<O>
<![CDATA[新建标题]]></O>
<FRFont name="SimSun" style="0" size="72"/>
<Position pos="0"/>
</WidgetTitle>
<Alpha alpha="1.0"/>
</Border>
<FormElementCase>
<ReportPageAttr>
<HR/>
<FR/>
<HC/>
<FC/>
</ReportPageAttr>
<ColumnPrivilegeControl/>
<RowPrivilegeControl/>
<RowHeight defaultValue="723900">
<![CDATA[1152000,723900,800100,723900,799200,799200,723900,723900,723900,723900,723900]]></RowHeight>
<ColumnWidth defaultValue="2743200">
<![CDATA[1104900,1440000,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200,2743200]]></ColumnWidth>
<CellElementList>
<C c="0" r="0">
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="0" s="0">
<O>
<![CDATA[储存链]]></O>
<PrivilegeControl/>
<Expand/>
</C>
<C c="1" r="1" s="1">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="BinCode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="1"/>
</C>
<C c="1" r="2" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="Barcode"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper">
<Attr divideMode="1"/>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<HighlightList>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Red]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='Red']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-65536"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[White]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='White']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-1"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Blue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='Blue']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-16776961"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Gray]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='Gray']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-1"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-8355712"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[Silver]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='Silver']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-2631719"/>
</HighlightAction>
</Highlight>
<Highlight class="com.fr.report.cell.cellattr.highlight.DefaultHighlight">
<Name>
<![CDATA[LightBlue]]></Name>
<Condition class="com.fr.data.condition.FormulaCondition">
<Formula>
<![CDATA[储存链.select(BackColor,BarCode=b3)='LightBlue']]></Formula>
</Condition>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.ForegroundHighlightAction">
<Foreground color="-16777216"/>
</HighlightAction>
<HighlightAction class="com.fr.report.cell.cellattr.highlight.BackgroundHighlightAction">
<Background name="ColorBackground" color="-10053121"/>
</HighlightAction>
</Highlight>
</HighlightList>
<Expand dir="0"/>
</C>
<C c="1" r="4" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.FunctionGrouper"/>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand dir="1" leftParentDefault="false" upParentDefault="false"/>
</C>
<C c="1" r="5" s="2">
<O t="DSColumn">
<Attributes dsName="储存链" columnName="PartNo"/>
<Complex/>
<RG class="com.fr.report.cell.cellattr.core.group.SummaryGrouper">
<FN>
<![CDATA[com.fr.data.util.function.CountFunction]]></FN>
</RG>
<Parameters/>
</O>
<PrivilegeControl/>
<Expand leftParentDefault="false"/>
</C>
</CellElementList>
<ReportAttrSet>
<ReportSettings headerHeight="0" footerHeight="0">
<PaperSetting/>
</ReportSettings>
</ReportAttrSet>
</FormElementCase>
<StyleList>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="120"/>
<Background name="ColorBackground" color="-3342388"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="1" size="72"/>
<Background name="ColorBackground" color="-13210"/>
<Border>
<Top style="1" color="-16777216"/>
<Bottom style="1" color="-16777216"/>
<Left style="1" color="-16777216"/>
<Right style="1" color="-16777216"/>
</Border>
</Style>
<Style horizontal_alignment="0" imageLayout="1">
<FRFont name="SimSun" style="0" size="72"/>
<Background name="NullBackground"/>
<Border>
<Top style="1"/>
<Bottom style="1"/>
<Left style="1"/>
<Right style="1"/>
</Border>
</Style>
</StyleList>
<heightRestrict heightrestrict="false"/>
<heightPercent heightpercent="0.75"/>
<IM>
<![CDATA[m9=p>;cgD?`jB?4EO`8t5[,D\E36ftG`3i!#UH0%1;2271O#_e&CQGnRS$Q/5fpp`dFq/LI>
gWaF/0:WH6&Xc(a10&Bi1lm!i!UW,dBH57*'o^nil6.TUc*H4*.gdI_FX:J)L&AcJEp8[=8"
^IV\>g40Q;e1?Z\Rs#;,D@*X\FH/WrJ!OK]AF!C'g[IM..9-[4+tJ:LWc0>=[MpB;p6H5>sUm
jp$Er5PTao5joBi>V+X_N@!JDCcg`r06U+P_/MoH-`a#8b*Pe&R51G<@`OtgV82<2!`boN3[
QmC$U[1X^>OGA?U=*Zh(:$8eqPRZ\qWnk/$VS;n'63[Pftq2G43eUBm^YDbLicVlth=Ap'=I
FkAUaWpQ"X$/R$`ZcHoBF-,'E/,57b3<#NpbdCF>O#J<%_&A6!hEosbi<K[dcOd`U@cXYA2H
$QslF3\;]AMrp/M'u0)WlQ&'6h7VIGNR4d.n_6YMCg.'SkmW"M&MmfcJJ8UkGt<4LREr!*AIh
\V2DoC+W@1T)3d^%l%I4h2e`cJ=F&V.<S,%_f-u*\Bdm$s&/?WP\c.mQB`/BNQ,f_>WP6qs2
/P<o0\DZ3rCC-qSs1aL%FV#8Gct_TP:F&<+@?f]Ak7U9HX,i6H'MeWRX)K[*@>cd,faY,S7#7
[6``eM&^"5:+ZbuE(WEEYl'Ck=WlDop,1Qeqr>=u9?fMf9UPb-/Y]ADc1Q=cGgF[QS3*h+(g_
``A&+#O6WU("K+Y-ul9\jG3WrSCR1h_>JAQKb8R*/hpiqs'4`a;Q33Oa2)Ds3I;sheA;o1qj
;/\M%np4Q7a*#%hu\3M+MT\7'DjmK'U^G/%fdZ>[@`e4NE>d`M\(.X$<+_=mjA6M+sUU5MAU
<eei;P"qMT\ipWEaLII,(R,uKJP!hh$$&\igX^9>us"'Wp'Wl]AKPGZg*oL5:&YIY]Ase+q;gp
6C_2Ha<9D6]AY\@*Q&@tOC7lX@lT%Z@G6Ep,uWs9o^hfn8@KpebP8K1OJ.GQ!V^V4l;8n6:NY
/,E]A3`R>@_`:c)KE,A\mejR]AC#]ApcaGQEMG1"S3BWmAoF5j_kV$\aa+qN_@WN5pOn(Sd+#%$
BZA<.%VatPdn#T!//dgnc8VjYd@S(^.Sq8NV%6X7b8o>[^<Q:Al*'Rsar/tZnmmcR1HUBG@r
b`XS2ts4cX'qpjp]Ad7`57:tgCD]AA^.qfMVS*Ae@+X<.,KnO@X'WXbp`KtMhEc83'I:;0Y:Gs
uDGU#?mK9cRM$H+$lj]A3U!KR;O2!!&Z]AkumGD+aIS0?q[cGO_N)VL75k_Wtcrm]AOf%/kZ[Tj
Ueq#l!G6e8%)2X'>CGF$7W^S1/4G,SmV9D2MM*tM%o^Pe)0a9r7#KPK8'n/N,/^<a1d'egTY
"HVuO1/F0ZW(Y?b+g3VOC*AG+'+2`pG517b48qJ0?#=QFRRA4J7@0tK*#ZP(P-M;BfIOAXEu
'MheY>O`+SQo`t*UFT<I;`nYFHW5[@)OVA)S''_R.<8Q#YY2S=g&>4T=qXj!rIQII@=DB^&i
[_h.H3V(pV,<K.r_%t@uig1(1=#"$qC=/WW!4X#[&jBh<?Jc[L+5tJjcbucZ,R)7GDDkZ$Im
gntK3q3,V,C9q)rG`lb4q&V#SQ1)-a&A;E#?<PTJo!uLF(3HT.n!Q/!HPfYJO?>D/2X!OJ<<
d*,l:^q>Z-2/H^j018hcCVP_7#&X'S&tO_,L59#=os%4gShV(U`J1"ft2=[BK(H*>=\5Uk8E
5HB-@Zi;>4'PZ?WO:\o<"%YPl=#H@8AkPP;C%i`Pm?Ua/FLpaB%[n2cZ24UeOEKV?]A^O+OkL
XSRW1h_u36-gs0cY$^O]A#A[]AjC5ktGC9]AK6>=E871(bNaE_O[TR@sOH`tqNjkN,Osa<&"7m+
'Iu+lAmcoB$;c.>b(c5qZX\3jcfP.p?>*[[R+E:fQ(O.>cmp`h>a(.CRF&V%lB2be9.%BKr=
7%b8AYY\BEEe#:o[>!nMD>[daXSYN*-L)SlIoO=bR@g.SMHE]AklShO>n5H,e6ZNsUgD8eFjZ
G]AT]A+Vpb=&G:<BVo>okoX2?Wk6t)sJL9U,%/VK%/K*BlBX)^`I=R_"J#Wl0#R0TgIu]AKQAiE
$D:E=9,S9WT@5qS&`EC)u^^M,UGf?A-X,S^DWAV=0@;C/Mt[^^nJ)(5JMq]A&b+%t\1M$'#6n
*$I3k!6$`r_`\..[Bc6[p9PT^Cn'b1!=7dsZ9UJ<F.-St0]AZ;L%`bnV*]A@oT)+;YL)blF8H$
]A]A/mLU"iR2fc^*N!M^mR5)+\4LWBGH[8EM6j7D@L&EN"cm31gaot'ME)SDSmLX_*pI9/,"oW
=?I.RCaZ196C#"6/%Ts,3m=`1&]A\Q^YB8'<Q!de]A5<Ro^,`_@%S)/-f<9dm08JjI*iM\3:+(
\0;9;qL<b\#5A@>/3_Sg8Q]A9,-a7GCZJ^dhE3nl*@7G3ob>-oUY7\WD&,^tj%ZINg-$FDISM
a\$u"V%:lR#.WRJ&Rmu&BejK99G.\t/9flfDB*8U31hu$/(Z@lUYas!4KCE\kOQ5&]ApDEAm5
hH@-f:1U3'AR2a-,YXI?;ZdKr4U`A<r[G[2me7i]A7j"gpdA&n''dO>2eg`$+jKg,0'#[`ncg
aeVn=[2[d/';tqS&J=4Ao\)8?LW`4q"5>5;7Rn@Z5(*,j4(:QS]AHAOo?9"Kn4P%?5VLQ.:Dc
V'A5`,S#V;(YrS;dZ)4(aA[2FtgaTAS'SFqo;d;/>@k(RDc0qOB5oiU?*Z;V7=oD'Y4,[W8+
ngGFM88=WZunfj\-69u21r!)nHi_8AoEEgI2oCGL><5?MnTDC/3HOj++Y@=a0\u?NP]Ab<E_P
dm!]Au\0\8X8RX%f`\gLOmV&+pqnGTT<h-:YN*.eHI^eVb3P2Fn*uC1O*XfV-MI1t1U'U<uh*
H`1++)A^m[LQ?3I'gr.qP8LG#QImNoMMU0:%XkY!EYZ#q0\/2h2b4rB0/8i."Ztb+Ec.-735
]A(P:[hOm(('tn4%G!<'=#ikHr2+YT/_pslUi?^@m&Z"IaLmK%p=(P+D/QQFsnq25(Ic4a"AS
4Ng%E9:NZcL>q0-7V\M^d]AM]AJNE4KsgrP2'F/lBc_eW3q0.HQN%PR>P8F/#rc\J_(8DqR%5O
k;B)F@r8PZFGU(g(_i%?3m*0M(jS-TnHPk\rTJ$WF@(#lXku+?l]AHF2\sWN5Jr!?>`!\L@68
BoUDRIh@^gGA<9V8enpVT8p)*nJod[8ojlo9rk:\c[S"/dY9;q6M:E??Y3H?\^YJ.k($J4=p
\8S^fP^q@2?[dFirY+F878,DB'_g'H/0ZdGnZPF'2nq^-g3(]AnMcBp&hj8nA1`N1R:pMlJCb
DtY`DL(nFmj)[^?T1OrDeI<39NcX2[=-!?\%S-k-+9<(k>]AP)Zb"Mi0fBE1#=1aH\uM,oTW!
.HE$#j2_TUX+^jT._Q%lDd&*+,T,.N`ic1SD@3'jeh;VO!lhF+6%b1B9M@\cU>C"V*Lb>]A]A#
>Y3(^`79rI62D&TTJ\7XAn"i#!+)jK@+q0[XfrBYkDYbLOp^&A._]APj!4:r<WA3_(3=G:QF+
bA/OW=8hY_&bgT]A_Kli@[jI\)'kRQsjjjd;+\2HH<50$'0C6j$M+qd/h5!A2O]A^7M"m\U)\U
*lmOTJOJ2h1<p*+3^l27Y*AE.Im^X:I4rE!5UnBaKr6fm91>-b@0L+Y!+h[568YU*DfGsVa)
mnV__29O5Bi,H/4=!2k\EWbbJfJ6-=T<2Hkt<D'+fldb)K<Xl,-mmACTEZV"TZY?\rmtG6O<
B*/\Ah&cIFC?G7%ESEP<;+#;PU1#cl_a9SQ-&#9F<>)ios7'k+O!YrDS2cYVh#=sV7]As\CU0
$lo(X#2k(J-):4<i7%C35r9Tg^LA(6;b75N$j3BI%L![3IBP_E7lC>HBc6P(FN;eK%PS25:j
60gKBEb42MUj9Fs*mJ?T&-<A'/FD4!a'WZjOL0k?Q[3NYYq'QTD5k6h6C^cM\rDBU#aK.F:Q
pfR]AC2NUr<>d5q^QYD8b7AcXZG74=K26(f>MU8QF/:<I$9XRfks03^OPe8O`cLCC*n4*oD=K
E&D+Tcoo',djt.Fchl7/"-30<n%-1.b<lT$$[Q6UEV@U5tA6;DC>T]ACqQP*Ir5Rangt.Miq3
:N2&1(<nIJa<TEg$6XL`c1b&.I]AeN\Mf%+[T4!#b$e.RD]AVjK$E16\P)QLdY46m@oQQ^J74r
e^D@n?nYsLl4O[OE/*4lI0X^W,u+*o>UgeM'74%8<(YrfGTOD(_A?K)f7@CYLFP+q6<S1(*&
"`p<Q$lH9u(G#R`3tl:V>"dB.nE'P)"(K2=1/$Y3lJW=;]AGFrgq',M2*]Aq%^d+iLTFM\drbs
Lf;]AW8e</+4%H4RN\e0;*DZ^4[mOr55\9LME&emHR>c9u-@ZJdWGBC1!S'W1R]AN+9gE%dRH>
oWu`QVAGjCokh8/<eU*I&ZjkJMG!&+1\.>N65OmNI#56<gmn-(J'K:93Z/S^ZpH^ebWoZ$%#
8>C"jkPKetlnuuF)VY.VV%5(p8d;'.lOj%W"5aBdTXE>Q:D]A!\8+]Ab3e+5nGVN1MZ#dWa\OS
'M)QWT<0$Z9gkDbV"R_VoP8?+g+dp?9(NQZdJ->T4H^doRg=$OI>IUH6;a<P1;]AoRu^[3^HQ
XcHGn!"riQMc[c>[a.q`IOG:tR`!KE'Nq\pLHB8.MS7#2q2h<@7k=]AU=[X,JO6qY'&a%^oPR
"T)M9Fe?iCXVZJ@,>0qK/6B<RFJ"QW]A4FP/#1`?)De5H'FWh_h\0?5$O5-),d_"[DQ;3Ug[.
YZ(.:/>Tn9B+ji>d\o07\<87F_Lf`tWCH9Erq2d]A"PAdGEApd,^D:>+XRPA49l%A:FVl<+fj
5mSbl(NL2P7?]AdNeZ:QF?J1B7j&bM:/%c41/0&:t8!L0.dMVMnkmXm1aO@7uKh00fS5i;%WK
p`E)&Il"gemsoMO[U_'YSA":@Y=+^]AB/qJo%bDYjs2B<:<*B@qI=btH[&X]AIAN3f>RLL0ig9
WUU?OYXbI^b2A2XIRaM=K>DV`41NOV;\RjlmLb(_SJ^p"<u28XDJot.TRT>'ZS(sB;QdE;6i
=\mp,!Pb)L!s.AQ1tWj,]AW9@HMg7G;)dZR5e4KaRRu0844EL(Td!Ggb1NBWp-5V:J6F9[V'!
.KqCnfhlXl/d*Jos>K^9("G/r]Akm.lRN,'#B3%lXOd!j)uA3`rG'@JNKO>,5a%sYeR,1laUf
CgM#?/gJ+XP+Bj9$O]ALsb\]As$:Y#+/Qf/kEETq5MT!fVtVQr]A=C<J#!1*usr,6T$oc)Aj(OH
*RgE$38t<5+LMWp_;K&`S;ps<4^+E\\P@#om+QPc6EimnB)<ee2M=A0@*sN\%]A#&)$R=$AL%
M:T`5*h>f.mk7^LM3M'Ap+N+CSH1F@nEnoGp>3:b$:3<KtVl6'?,_Aarsh#LVfP9@5j<_s/H
VY(We?'f6K"Er%l'd_cDps;nG4gd'Lfg1Q&kHCH6V'>GbUhR;%Vs]AG-UF3OK9Q_6[p0GV58r
O"iZ^e4@9pIi[C^.fa6R%*U86NPQM2K-r8>4U1D8IOnX$3c5[W!oH3C6e$_@)D"WLN7iZ7/#
WcNZ$QpNLA%PjR>F"lI0Zf!Z*fD/BqAU#k21kn\F7m3HUOqiXZ=FjOS@BC?*l^pDDFT\.C[.
KLFIm0KsXei!OA-JUU=jD;V+*m]AlM.'D_AVDausJB[^hXus4!g%d"FATDn(/OCujaS=gnEq[
#8<9DNg\;nZppZO]APGLDQE]AaKlYmIs-"p37(<@No"W@\VY=R!:\j4Q0lQe(R'!o!dn_bh"uF
W;ODD\5DR2VAUf`99_^o=`*b_Pf[Pa7ZPjbO:%qa0.U0E\Q9R:efs$6O(I_Y<n7c<l/^IiR<
?^N<#J<@7*0MAWIu3U;=f:U+UZ!PFuo+[VDHWZ'FD]AGQ2j=\[q4A=2-r[.",\N$I#Ugj#Q-`
FGXu%S:ej2laZYNI>a1Vrj'bIL@G['\b4[rccF1hl=(sn)!3BGW;\JJ0),PSQJ:gL!MZUtDZ
=(8^BEjEeLm&N2=ct[nV6t7W;?LE9!iZI_X4Gd;aa.2,4c910LT*KK'K%Q9h]A;0s*j!J%@LK
gVJHYEPT>dCGNN#WmmMo4cYk)A'nfr@VE7:Q1Scs:b2W?#B?J9sC\B[L4f6!:i5#VHr.NOo,
s'9g.r:/;/cb]A$-l>h&T$Iq91rV-HV^EpmkSfYne#F4X^5NcurMo8`P?`?NXJo@L9j=kMS$*
9aPCOI!*I*Njr;OGP&YOYWiAZDA35Em"QTUU"p2VKH3D?/g/#J\fiY6f4P"$`OATCRA:Y.H7
<,_c<T+_liED7^1Gk10q!TYfp]AT+6</j^-Lj9"e-eDQL=XrR=MH\B?NQfJsRSs$PT9iH:(Fa
@bAmV2LYZHSSJMb9Y*o0K1t@PbU)VT?W^Mo>M$0^/:QprO%bK:GR0Umf^AtSNmt41-1:F2Q8
&ep586dfR%fOcL>;T_gM<T,p!m?^WdALW__0M2Eu=&S&DIfEEoW!WdorI#9QH,)CbM&=Q#EE
As/mhJ/MK:$u<aP8cQ:doBdGQFa(R,bBBl#[;4>o$=DVUjIJi\*"2[U.K9k7]A^ZiDBf#g;pG
apeVo",#i4cDC<IAe;TS3T_8=5>JZf'4u7WThWi1+be3)i+d+ci\n#HYcMLWiqa`NN'W"=5N
[=lUhhQkY]AN1oD-6%H-Xa/s%k@:\ka?9I)(;p^W[[6rc_l*rUS>Rl%Tq8Skljn',Scor6Olr
0-#fNAG%_B$GJsm`Q9A-f53Fs1QL$q1X]AkYDN8a~
]]></IM>
<ElementCaseMobileAttrProvider horizontal="1" vertical="1" zoom="true" refresh="false" isUseHTML="false" isMobileCanvasSize="false" appearRefresh="false" allowFullScreen="false"/>
</body>
</InnerWidget>
<BoundsAttr x="610" y="0" width="665" height="762"/>
</Widget>
<Sorted sorted="false"/>
<MobileWidgetList>
<Widget widgetName="report0"/>
<Widget widgetName="report1"/>
</MobileWidgetList>
<WidgetZoomAttr compState="0"/>
<AppRelayout appRelayout="true"/>
<Size width="1275" height="762"/>
<ResolutionScalingAttr percent="0.9"/>
<BodyLayoutType type="0"/>
</Center>
</Layout>
<DesignerVersion DesignerVersion="KAA"/>
<PreviewType PreviewType="0"/>
<TemplateIdAttMark class="com.fr.base.iofile.attr.TemplateIdAttrMark">
<TemplateIdAttMark TemplateId="cc5b9346-dbb1-4696-bbc3-9d46d205f899"/>
</TemplateIdAttMark>
</Form>
