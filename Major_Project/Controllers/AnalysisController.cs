using Major_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Major_Project.Controllers
{
    public class JsonClass
    {
        public List<string> label { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public JsonClass()
        {
            this.label = new List<string>();
        }
    }
    
    public class AnalysisController : Controller
    {
        //
        // POST: /Analysis/
        public ActionResult Index(int? id)
        {
            int tempId;// used to store the generated random numbers Through Random objt
            Random random = new Random();
            Major_ProjectEntities db = new Major_ProjectEntities();      
            //db.sp_emptyall();
            //db.sp_stepfirst();
            //db.sp_stepsecond("item_id1","item_id2");
            //db.sp_movetofinalAmerge(2);

            db.sp_emptyall();
            db.sp_stepfirst();
            db.sp_stepsecond("item_id1", "item_id2");
            db.sp_movetofinalAmerge(2);

            //db.sp_refresh();
            ////db.sp_stepfirst();
            //db.sp_stepsecond("item_id2", "item_id3");
            //db.sp_movetofinalAmerge(3);


            List<string> result = db.prune().ToList();
            List<string> str = new List<string>();
            List<string> final = new List<string>();
            int state = 0;
            int counter = 0;
            foreach (string rslt in result)
            {
                str.AddRange(rslt.Split(',').ToList());
                foreach(string s in str)
                {
                    counter++;
                    if (id ==int.Parse(s))
                    {
                        state = 1;
                        break;
                    }
                }  
                if(state==1)
                {
                    str.RemoveAt(counter - 1);
                    final.AddRange(str);
                }
                state = 0;
                counter = 0;
                str.Clear();
            }
            List<item> itm = new List<item>();  //items to be returned
            if (final.Count() < 1)
            {
                for (int i = 0; i < 12; i++)
                {


                    tempId = random.Next(db.tbl_const.Select(x => x.item_id).Min(), db.tbl_const.Select(x => x.item_id).Max());
                    var othersObject = (from m in db.items where m.item_id == tempId select m).Single();
                    itm.Add(new item()
                    {
                        item_id = tempId,
                        item_name = othersObject.item_name,
                        item_price = othersObject.item_id
                    }
                     );

                }
            }
            else
            {
                var distinct = final.Select(x => x).Distinct();
                foreach (string strr in distinct.ToList())
                {
                    foreach (var item in db.items.ToList())
                    {
                        if (item.item_id == int.Parse(strr))
                        {
                            itm.Add(item);
                        }
                    }
                }
            }
            

            //details data
           var data = (from m in db.items where m.item_id==id select m).Single();
           ViewBag.ID = data.item_id;
           ViewBag.Name = data.item_name;
           ViewBag.Category = data.category;
           ViewBag.Price = data.item_price;

            //for others 
           var itmlist = new List<item>();
           
           
           
           for (int i = 0; i < 12;i++)
           {


               tempId  = random.Next(db.tbl_const.Select(x => x.item_id).Min(), db.tbl_const.Select(x => x.item_id).Max());
               var othersObject = (from m in db.items where m.item_id == tempId select m).Single();
               itmlist.Add(new item()
               {
                   item_id = tempId,
                   item_name = othersObject.item_name,
                   item_price = othersObject.item_id
               }
                );
              
           }
               
           
           
          
           ViewBag.items = itmlist;

           return View(itm);
        }
        
        public ActionResult ShowChart(int id)
        {
            
            //int id=167;

            List<JsonClass> returnObject = new List<JsonClass>();
            Major_ProjectEntities db = new Major_ProjectEntities();
          // List<int> count= db.count_itemcount().ToList();
            List<int> count= new List<int>();
            var counter = db.count_itemcount().ToList();
            foreach(int t in counter)
            {
                count.Add(t);
            }
                    
            List<string> merged_result= db.count_itemname().ToList();
            List<string> tempStr= new List<string>();
            List<int> existentindex=new List<int>(); //index later used during count access to skip non existent data
            int mergedindex = 0;//tracks the location of current mergeditem
            int state = 0;//boolean to indicate existence and inexistence
            int innercounter = 0;//used to store the index location of the searched item for removal
            int nooItems = 0; // counter for 5 items of concern
            foreach (string str in merged_result)//for  1
            {       
                tempStr.AddRange(str.Split(','));
                foreach(string s in tempStr)
                {
                    if(id == int.Parse(s))
                    {
                        existentindex.Add(mergedindex);
                        state = 1;
                        break;
                    }
                    ++innercounter;
                }
                
                if(state==1)
                {
                    tempStr.RemoveAt(innercounter);

                    JsonClass tempObj = new JsonClass();
                    foreach (string s in tempStr)
                    {
                        foreach (var item in db.items.ToList())
                        {
                            if (item.item_id == int.Parse(s))
                            {
                                tempObj.label.Add(item.item_name);
                            }
                        }
                    }
                   
                    ///tempObj.label.AddRange(tempStr);

                    returnObject.Add(tempObj);
                    ++nooItems;
                    state = 0;
                }
                if (nooItems >4)
                {
                    break;
                }
                innercounter = 0;
                tempStr.Clear();
                ++mergedindex;
            }//end of for 1
            int x2 = 100;
           for(int i=0;i<returnObject.Count();i++) //for 2
           {
               returnObject[i].x2 = x2;
               returnObject[i].y2 = count[existentindex[i]];
               x2 += 100;

           }//end of for 2
           //List<JsonClass> fiveresults = new List<JsonClass>();

           
           return Json(returnObject, JsonRequestBehavior.AllowGet);

        }//end f show chart action

        

        }//controller
	}//namespace
