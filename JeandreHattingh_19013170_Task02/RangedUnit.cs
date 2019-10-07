using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JeandreHattingh_19013170_Task02
{
    class RangedUnit : Unit
    {
        Map mapTracker = new Map(20, 20, 10, 4);

        //Uses constructor initialisers to call “Unit’s” constructor with relevant values for a specific Unit
        public RangedUnit(int randgedX, int rangedY, string rangedTeam, char rangedSym, bool rangedEngaging, string rangedName) : base(randgedX, rangedY, 6, 3, 1, 2, rangedTeam, rangedSym, rangedEngaging, rangedName)
        {

        }

        public RangedUnit(int randgedX, int rangedY, int rangedHP, int rangedMaxHP, string rangedTeam, char rangedSym, bool rangedEngaging, string rangedName) : base(randgedX, rangedY, rangedHP, rangedMaxHP, 3, 1, 2, rangedTeam, rangedSym, rangedEngaging, rangedName)
        {

        }

        //A method to move to a new position
        public override string Move(Unit unitToEngage)
        {
            string returnVal = "";
            string typeCheck = unitToEngage.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit m = (MeleeUnit)unitToEngage;
                if ((Math.Abs(m.MuXPos - this.RuXPos) > Math.Abs(m.MuYPos - this.RuYPos)))
                {
                    if ((m.MuXPos - this.RuXPos) > 0)
                    {
                        this.RuXPos++;
                        returnVal = "Right";

                    }
                    else if ((m.MuXPos - this.RuXPos) < 0)
                    {
                        this.RuXPos--;
                        returnVal = "Left";
                    }
                }
                else
                {
                    if ((m.MuYPos - this.RuYPos) > 0)
                    {

                        this.RuYPos++;
                        returnVal = "Up";

                    }
                    else if ((m.MuYPos - this.RuYPos) < 0)
                    {
                        {
                            this.RuYPos--;
                            returnVal = "Down";
                        }
                    }
                }
            }
            else
            {
                RangedUnit r = (RangedUnit)unitToEngage;
                if ((Math.Abs(r.RuXPos - this.RuXPos) > Math.Abs(r.RuYPos - this.RuYPos)))
                {
                    if ((r.RuXPos - this.RuXPos) > 0)
                    {
                        this.RuXPos++;
                        returnVal = "Right";

                    }
                    else if ((r.RuXPos - this.RuXPos) < 0)
                    {
                        this.RuXPos--;
                        returnVal = "Left";



                    }
                }
                else
                {
                    if ((r.RuYPos - this.RuYPos) > 0)
                    {
                        this.RuYPos++;
                        returnVal = "Up";

                    }
                    else if ((r.RuYPos - this.RuYPos) < 0)
                    {
                        this.RuYPos--;
                        returnVal = "Down";

                    }
                }
            }

            return returnVal;
        }

        public string Move(Building buildingToEngage)
        {
            string returnVal = "";
            string typeCheck = buildingToEngage.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "FactoryBuilding")
            {
                FactoryBuilding fb = (FactoryBuilding)buildingToEngage;
                if ((Math.Abs(fb.FbXPos - this.RuXPos) > Math.Abs(fb.FbYPos - this.RuYPos)))
                {
                    if ((fb.FbXPos - this.RuXPos) > 0)
                    {
                        this.RuXPos++;
                        returnVal = "Right";

                    }
                    else if ((fb.FbXPos - this.RuXPos) < 0)
                    {
                        this.RuXPos--;
                        returnVal = "Left";
                    }
                }
                else
                {
                    if ((fb.FbYPos - this.RuYPos) > 0)
                    {

                        this.RuYPos++;
                        returnVal = "Up";

                    }
                    else if ((fb.FbYPos - this.RuYPos) < 0)
                    {
                        this.RuYPos--;
                        returnVal = "Down";
                    }
                }
            }
            else
            {
                ResourceBuilding gb = (ResourceBuilding)buildingToEngage;
                if ((Math.Abs(gb.RbXPos - this.RuXPos) > Math.Abs(gb.RbYPos - this.RuYPos)))
                {
                    if ((gb.RbXPos - this.RuXPos) > 0)
                    {
                        this.RuXPos++;
                        returnVal = "Right";

                    }
                    else if ((gb.RbXPos - this.RuXPos) < 0)
                    {
                        this.RuXPos--;
                        returnVal = "Left";



                    }
                }
                else
                {
                    if ((gb.RbYPos - this.RuYPos) > 0)
                    {
                        this.RuYPos++;
                        returnVal = "Up";

                    }
                    else if ((gb.RbYPos - this.RuYPos) < 0)
                    {
                        this.RuYPos--;
                        returnVal = "Down";

                    }
                }
            }

            return returnVal;
        }

        //A method to handle combat with another unit
        public override void Combat(Unit attackingUnit)
        {
            string typeCheck = attackingUnit.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];
            switch (typeCheck)
            {
                case "MeleeUnit":
                    MeleeUnit mu = (MeleeUnit)attackingUnit;
                    mu.MuHealth -= this.RuAtk;
                    this.RuEngaging = false;
                    break;
                case "RangedUnit":
                    RangedUnit ru = (RangedUnit)attackingUnit;
                    ru.RuHealth -= this.RuAtk;
                    this.RuEngaging = false;
                    break;
                default:
                    break;
            }
        }

        public void Combat(Building attackingBuilding)
        {
            string typeCheck = attackingBuilding.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];
            switch (typeCheck)
            {
                case "FactoryBuilding":
                    FactoryBuilding fb = (FactoryBuilding)attackingBuilding;
                    fb.FbHealth -= this.RuAtk;
                    this.RuEngaging = false;
                    break;
                case "ResourceBuilding":
                    ResourceBuilding gb = (ResourceBuilding)attackingBuilding;
                    gb.RbHealth -= this.RuAtk;
                    this.RuEngaging = false;
                    break;
                default:
                    break;
            }
        }

        //A method to determine whether another unit is within attack range
        public override bool Engaging(Unit unitInRange)
        {
            bool inRange = false; ;
            string typeCheck = unitInRange.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];
            switch (typeCheck)
            {
                case "MeleeUnit":
                    {
                        MeleeUnit mu = (MeleeUnit)unitInRange;
                        if ((mu.MuYPos == this.RuYPos && Math.Abs(mu.MuXPos - this.RuXPos) == 2) || (mu.MuXPos == this.RuXPos && Math.Abs(mu.MuYPos - this.RuYPos) == 2))
                        {
                            inRange = true;
                        }
                        else
                        {
                            inRange = false;
                        }
                    }
                    break;
                case "RangedUnit":
                    {
                        RangedUnit ru = (RangedUnit)unitInRange;
                        if ((ru.RuYPos == this.RuYPos && Math.Abs(ru.RuXPos - this.RuXPos) == 2) || (ru.RuXPos == this.RuXPos && Math.Abs(ru.RuYPos - this.RuYPos) == 2))
                        {
                            inRange = true;
                        }
                        else
                        {
                            inRange = false;
                        }
                    }
                    break;
                default:
                    break;
            }
            return inRange;
        }

        public bool Engaging(Building buildingInRange)
        {
            bool inRange = false; ;
            string typeCheck = buildingInRange.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];
            switch (typeCheck)
            {
                case "FactoryBuilding":
                    {
                        FactoryBuilding fb = (FactoryBuilding)buildingInRange;
                        if ((fb.FbYPos == this.RuYPos && Math.Abs(fb.FbXPos - this.RuXPos) == 2) || (fb.FbXPos == this.RuXPos && Math.Abs(fb.FbYPos - this.RuYPos) == 2))
                        {
                            inRange = true;
                        }
                        else
                        {
                            inRange = false;
                        }
                    }
                    break;
                case "ResourceBuilding":
                    {
                        ResourceBuilding rb = (ResourceBuilding)buildingInRange;
                        if ((rb.RbYPos == this.RuYPos && Math.Abs(rb.RbXPos - this.RuXPos) == 2) || (rb.RbXPos == this.RuXPos && Math.Abs(rb.RbYPos - this.RuYPos) == 2))
                        {
                            inRange = true;
                        }
                        else
                        {
                            inRange = false;
                        }
                    }
                    break;
                default:
                    break;
            }
            return inRange;
        }

        //A method to return position of the closest other unit to this unit
        public override Unit EnemyPos(Unit[] unitClosetCheck)
        {
            int result;
            int xDistance;
            int yDistance;
            int closest = 1000;
            Unit returnVal = this;
            foreach (Unit temp in unitClosetCheck)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                switch (typeCheck)
                {
                    case "MeleeUnit":
                        {
                            MeleeUnit m = (MeleeUnit)temp;
                            if (m.MuXPos != this.RuXPos && m.MuYPos != this.RuYPos)
                            {
                                xDistance = Math.Abs(this.RuXPos - m.MuXPos);
                                yDistance = Math.Abs(this.RuXPos - m.MuYPos);
                                result = Convert.ToInt32(Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance)));

                                if (result < closest)
                                {
                                    closest = result;
                                    returnVal = m;
                                }
                            }
                        }
                        break;
                    case "RangeUnit":
                        {
                            RangedUnit r = (RangedUnit)temp;
                            if (r.RuXPos != this.RuXPos && r.RuYPos != this.RuYPos)
                            {
                                xDistance = Math.Abs(this.RuXPos - r.RuXPos);
                                yDistance = Math.Abs(this.RuYPos - r.RuYPos);
                                result = Convert.ToInt32(Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance)));

                                if (result < closest)
                                {
                                    closest = result;
                                    returnVal = r;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return returnVal;
        }

        public Building EnemyPos(Building[] buildingClosetCheck)
        {
            int result;
            int xDistance;
            int yDistance;
            int closest = 1000;
            Building returnVal = null;
            foreach (Building temp in buildingClosetCheck)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                switch (typeCheck)
                {
                    case "FactoryBuilding":
                        {
                            FactoryBuilding fb = (FactoryBuilding)temp;
                            if (fb.FbXPos != this.RuXPos && fb.FbYPos != this.RuYPos)
                            {
                                xDistance = Math.Abs(this.RuXPos - fb.FbXPos);
                                yDistance = Math.Abs(this.RuXPos - fb.FbYPos);
                                result = Convert.ToInt32(Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance)));

                                if (result < closest)
                                {
                                    closest = result;
                                    returnVal = fb;
                                }
                            }
                        }
                        break;
                    case "ResourcesBuilding":
                        {
                            ResourceBuilding rb = (ResourceBuilding)temp;
                            if (rb.RbXPos != this.RuXPos && rb.RbYPos != this.RuYPos)
                            {
                                xDistance = Math.Abs(this.RuXPos - rb.RbXPos);
                                yDistance = Math.Abs(this.RuYPos - rb.RbYPos);
                                result = Convert.ToInt32(Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance)));

                                if (result < closest)
                                {
                                    closest = result;
                                    returnVal = rb;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return returnVal;
        }

        //A method to handle the death/ destruction of this unit
        public override bool Death()
        {
            bool unitDead;

            if (this.RuHealth <= 0)
            {
                unitDead = true;
            }
            else
            {
                unitDead = false;
            }

            return unitDead;
        }

        //A method to move to a new position
        public string RandomMove()
        {
            Random rgn = new Random();
            int move = rgn.Next(0, 4);
            string moveDirection = "";

            switch (move)
            {
                case 0:
                    {
                        moveDirection = "Right";
                        break;
                    }
                case 1:
                    {
                        moveDirection = "Left";
                        break;
                    }
                case 2:
                    {
                        moveDirection = "Up";
                        break;
                    }
                case 3:
                    {
                        moveDirection = "Down";
                        break;
                    }
            }

            return moveDirection;
        }

        //A ToString() method to return a neatly formatted string showing all the unit information
        public override string ToString()
        {
            string returnVal = "";
            returnVal += "A new Ranged Unit enters the battlefield" + Environment.NewLine;
            returnVal += "The untis' name is: " + this.RuName + Environment.NewLine;
            returnVal += "The untis' X position is: " + this.RuXPos + Environment.NewLine;
            returnVal += "The untis' Y position is: " + this.RuYPos + Environment.NewLine;
            returnVal += "The untis' current HP is: " + this.RuHealth + Environment.NewLine;
            returnVal += "The untis' maximum HP is: " + this.RuMaxHealth + Environment.NewLine;
            returnVal += "The untis' attack damage is: " + this.RuAtk + Environment.NewLine;
            returnVal += "The untis' attack range is: " + this.RuAttkRange + Environment.NewLine;
            returnVal += "The untis' movement speed is: " + this.RuMovementSpeed + Environment.NewLine;
            returnVal += "The untis' team is: " + this.RuTeam + Environment.NewLine;
            returnVal += "The untis' symbol is: " + this.RuSymbol + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        //A method to handle saving for the Unit
        public override void Save()
        {
            string savedString = "";
            savedString += "Ranged,";
            savedString += RuXPos + ",";
            savedString += RuYPos + ",";
            savedString += RuName + ",";
            savedString += RuHealth + ",";
            savedString += RuMaxHealth + ",";
            savedString += RuMovementSpeed + ",";
            savedString += RuAtk + ",";
            savedString += RuAttkRange + ",";
            savedString += RuTeam + ",";
            savedString += RuSymbol + ",";
            savedString += RuEngaging;

            FileStream fs = new FileStream("SavedUnits/unitTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }

        //Accessors for the specific class
        public int RuXPos { get => base.xPos; set => base.xPos = value; }
        public int RuYPos { get => base.yPos; set => base.yPos = value; }
        public int RuHealth { get => base.hp; set => base.hp = value; }
        public int RuMaxHealth { get => base.maxHP; }
        public int RuMovementSpeed { get => base.speed; }
        public int RuAtk { get => base.atk; }
        public int RuAttkRange { get => base.atkRange; }
        public string RuTeam { get => base.team; }
        public char RuSymbol { get => base.symbol; }
        public bool RuEngaging { get => base.engage; set => base.engage = value; }
        public string RuName { get => base.name; set => base.name = value; }
    }
}

