using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //public String ATTACK_NAME=Action.createPrimitiveAttack(0,0).getType().name(); //change this to be a specific takable action when everything else done
	StateView currentState; //describes a hypothetical state for movement
	//List<int> myUnitID; //from the computer perspective
	//List<int> enemyUnitID;

    //will calling this program refresh PUM or does it need to go in a void update?

    public GameObject Selectionbox = GameObject.Find("Controller"); //using this instead of the int unitIDs (will be refering to units by name)
    public PlayerUnitManager PUM = Selectionbox.GetComponent<PlayerUnitManager>();
    List<GameObject> myUnitID = PUM.enemyUnits;
    List<GameObject> enemyUnitID = PUM.PlayerUnits;

	//Map<Integer, CombatUnit> units;
    Dictionary<GameObject, CombatUnit> units;
	List<CombatUnit> myUnitList;
	List<CombatUnit> enemyUnitList;

	double currentStateUtility;
	bool utilityWasCalculated;
	
	//bounds of map
	int xBound;
	int yBound;
	
	//if it is our move
	bool ourMove;
	
	
	/*
	 * REPLACE WITH ENEMY CHARACTERISTICS
	 */
	private class CombatUnit{
        private int xPosition;
        private int yPosition;
        private int id;
        private int attackDamage;
        private int range;
        private int baseHealth;
        private int currentHealth;

        private CombatUnit(int id){
            this.id = id;
        }

        public int EntityId() {
            return id;
        }

        public int getXPosition() {
            return xPosition; //get from unity
        }

        public void setXPosition(int xPosition) {
            this.xPosition = xPosition;
        }

        public int getYPosition() {
            return yPosition; //get from unity
        }

        public void setYPos(int yPosition) {
            this.yPosition = yPosition;
        }

        public void setBaseHealth(int baseHealth) {
            this.baseHealth = baseHealth;
        }

        public int getBaseHealth() {
            return baseHealth;
        }

        public void setCurrentHealth(int currentHealth) {
            this.currentHealth = currentHealth;
        }
        
        public int getCurrentHealth() {
            return currentHealth;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId; //indicates if the unit is friendly or a target
        }
        
        public int getPlayerId() {
            return playerId;
        }

        public int getRange() {
            return range;
        }
        
        public void setRange(int range) {
            this.range = range;
        }

        public void setAttackDamage(int attackDamage) {
            this.attackDamage = attackDamage;
        }
        
        public int getAttackDamage() {
            return attackDamage;
        }
    }

    /**
     * You will implement this constructor. It will
     * extract all of the needed state information from the built in
     * SEPIA state view.
     *
     * You may find the following state methods useful:
     *
     * state.getXExtent() and state.getYExtent(): get the map dimensions
     * state.getAllResourceIDs(): returns the IDs of all of the obstacles in the map
     * state.getResourceNode(int resourceID): Return a ResourceView for the given ID
     *
     * For a given ResourceView you can query the position using
     * resource.getXPosition() and resource.getYPosition()
     * 
     * You can get a list of all the units belonging to a player with the following command:
     * state.getUnitIds(int playerNum): gives a list of all unit IDs beloning to the player.
     * You control player 0, the enemy controls player 1.
     * 
     * In order to see information about a specific unit, you must first get the UnitView
     * corresponding to that unit.
     * state.getUnit(int id): gives the UnitView for a specific unit
     * 
     * With a UnitView you can find information about a given unit
     * unitView.getXPosition() and unitView.getYPosition(): get the current location of this unit
     * unitView.getHP(): get the current health of this unit
     * 
     * SEPIA stores information about unit types inside TemplateView objects.
     * For a given unit type you will need to find statistics from its Template View.
     * unitView.getTemplateView().getRange(): This gives you the attack range
     * unitView.getTemplateView().getBasicAttack(): The amount of damage this unit type deals
     * unitView.getTemplateView().getBaseHealth(): The initial amount of health of this unit type
     *
     * @param state Current state of the episode
     */
    public GameState(StateView state) {
        currentStateUtility = 0;
        currentState = state;
        //myUnitID = state.getUnitIds(0); //search for tag Enemy - importing from PUM
        //enemyUnitID = state.getUnitIds(1); //search for tag Player - importing from PUM
        units = new Dictionary<GameObject, CombatUnit>();
        myUnitList = new ArrayList<>();
        enemyUnitList = new ArrayList<>();
        
        //bounds of map
        xBound = state.getXExtent();//get from scene
        yBound = state.getYExtent();//get from scene
        
        //we move first
        this.ourMove = false; //we should pass from turnmanager
        //utility has not been calculated at the beginning of the program
        utilityWasCalculated = false;
        
        //get from EnemyPieces instead of setting up: already exists in resource folder
        foreach(GameObject unitID in myUnitID) {
        	CombatUnit newUnit = new CombatUnit(unitID);
        	
        	UnitTemplate.UnitTemplateView unitTemplate = state.getUnit(unitID).getTemplateView();
        	
        	//initialize
        	newUnit.setPlayerId(0);
        	newUnit.setAttackDamage(unitTemplate.getBasicAttack());
        	newUnit.setRange(unitTemplate.getRange());
        	newUnit.setBaseHealth(unitTemplate.getBaseHealth());
        	newUnit.setCurrentHealth(newUnit.getBaseHealth());
        	newUnit.setXPosition(state.getUnit(unitID).getXPosition());
        	newUnit.setYPos(state.getUnit(unitID).getYPosition());
        	
        	//units.put(unitID, newUnit);
            units[unitID] = newUnit;

        	myUnitList.add(newUnit);
        }
        
        //get from PlayerPieces instead of setting up, similar idea
        foreach(GameObject unitID in enemyUnitID) {
        	CombatUnit newUnit = new CombatUnit(unitID);
        	
        	UnitTemplate.UnitTemplateView unitTemplate = state.getUnit(unitID).getTemplateView();
        	
        	//initialize
        	newUnit.setPlayerId(1);
        	newUnit.setAttackDamage(unitTemplate.getBasicAttack());
        	newUnit.setRange(unitTemplate.getRange());
        	newUnit.setBaseHealth(unitTemplate.getBaseHealth());
        	newUnit.setCurrentHealth(newUnit.getBaseHealth());
        	newUnit.setXPosition(state.getUnit(unitID).getXPosition());
        	newUnit.setYPos(state.getUnit(unitID).getYPosition());
        	
        	//units.put(unitID, newUnit);
            units[unitID] = newUnit;

            enemyUnitList.add(newUnit);
        }
    }
    
    /*
     * this will be called throughout the program to update the agent values after each turn
     * the constructor above was to initialize all the unit values
     *make adjustments accordingly similar to constructor
     */
    public GameState(GameState state) {
    	
    	this.myUnitID = state.myUnitID;
    	this.enemyUnitID = state.enemyUnitID;
    	this.units = state.units;
    	this.myUnitList = state.myUnitList;
    	this.enemyUnitList = state.enemyUnitList;
    	
    	this.xBound = state.xBound;
    	this.yBound = state.yBound;
    	
    	this.utilityWasCalculated = state.utilityWasCalculated;
    	this.currentStateUtility = state.currentStateUtility;
    	
    	//other person turn
    	this.ourMove = !state.ourMove;
    }

    /**
     * You will implement this function.
     *
     * You should use weighted linear combination of features.
     * The features may be primitives from the state (such as hp of a unit)
     * or they may be higher level summaries of information from the state such
     * as distance to a specific location. Come up with whatever features you think
     * are useful and weight them appropriately.
     *
     * It is recommended that you start simple until you have your algorithm working. Then watch
     * your agent play and try to add features that correct mistakes it makes. However, remember that
     * your features should be as fast as possible to compute. If the features are slow then you will be
     * able to do less plys in a turn.
     *
     * Add a good comment about what is in your utility and why you chose those features.
     *
     * @return The weighted linear combination of the features
     */
    public double getUtility() {
    	if (utilityWasCalculated) {
    		return currentStateUtility;
    	}
    	currentStateUtility = 0;

    	double distanceWeight = 100.0;
    	double blockageWeight = 100.0;
    	
    	currentStateUtility += utilityOfUnits();
    	currentStateUtility += utilityOfEnemyUnits();
    	currentStateUtility += utilityOfEnemyInRange();
    	//currentStateUtility += distanceToEnemy();
        //currentStateUtility += distanceWeight * utilityOfDistance();
    	//currentStateUtility += myUnitHealth();
    	//currentStateUtility += enemyUnitHealth();
    	//etc

        currentStateUtility += blockAdjustedDistance();
        currentStateUtility += - blockageWeight * totalBlockage();

    	utilityWasCalculated = true;
    	
        return currentStateUtility;
    }
    
    //if there are no more friendly units, return the smallest value
    private double utilityOfUnits() {
    	if(myUnitID.size() == 0) {
    		return Double.NEGATIVE_INFINITY;
    	}
    	return myUnitID.size();
    }
    
    //if there are no more enemy units, return max value
    private double utilityOfEnemyUnits() {
    	if(enemyUnitID.size() == 0) {
    		return Double.POSITIVE_INFINITY;
    	}
    	return -1*enemyUnitID.size();
    }
    
    //considering if there are enemies within range
    private double utilityOfEnemyInRange() {
    	double util = 0.0;
    	
    	foreach(CombatUnit unit in myUnitList) {
    		util += getEnemiesInRange(unit).size();
    	}
    	return util;
    }
    private List<CombatUnit> getEnemiesInRange(CombatUnit unit) {
    	List<CombatUnit> withinRange = new ArrayList<>();
    	foreach(CombatUnit enemy in enemyUnitList) {
    		if(distanceBetweenUnits(unit, enemy) <= unit.getRange()) {
    			withinRange.add(enemy);
    		}
    	}
    	return withinRange;
    }
    private double distanceBetweenUnits(CombatUnit unit1, CombatUnit unit2) {
    	int x1 = unit1.getXPosition();
    	int x2 = unit2.getXPosition();
    	int y1 = unit1.getYPosition();
    	int y2 = unit2.getYPosition();
    	
    	return Math.abs(x1 - x2) + Math.abs(y1 - y2);
    }
    
    //considering if my units are in range of enemy
    private double distanceToEnemy() {
    	double util = 0.0;
    	
    	foreach(CombatUnit unit in myUnitList) {
    		
    		double distance = Double.POSITIVE_INFINITY;
    		foreach(CombatUnit enemy in enemyUnitList) {
    			distance = Math.min(distanceBetweenUnits(unit, enemy), distance);
    		}
    		if(distance != Double.POSITIVE_INFINITY) {
    			util += distance;
    		}
    	}
    	return -1* util;
    }
    
    //utility function considering my total unit health
    private double myUnitHealth() {
    	double util = 0.0;
    	
    	foreach(CombatUnit unit in myUnitList) {
    		util += 1.0 * (double) unit.getCurrentHealth()/unit.getBaseHealth();
    	}
    	return util;
    }
    
    //utility function considering enemy unit health
    private double enemyUnitHealth() {
    	double util = 0.0;
    	
    	foreach(CombatUnit unit in enemyUnitList) {
    		util += 1.0*unit.getCurrentHealth()/unit.getBaseHealth();
    	}
    	return -1*util;
    }

    // utility function considering the distance to the closest archer to each footman
    private double utilityOfDistance() {
        double util = 0;

        foreach (CombatUnit friendly in myUnitList) {

            int minDistance = Integer.MAX_VALUE;
            foreach (CombatUnit enemy in enemyUnitList) {
                int distance = Math.abs(friendly.getXPosition() - enemy.getXPosition())
                        + Math.abs(friendly.getYPosition() - enemy.getYPosition());
                minDistance = Math.min(minDistance, distance);
            }
            util -= minDistance;
        }

        // division here keeps the distance of equal weight for all numbers of units
        return util / myUnitList.size();
    }

    private bool blocked(CombatUnit unit, CombatUnit target) {
        // columns
        for (int i = Math.min(unit.getXPosition(), target.getXPosition()); i <= Math.max(unit.getXPosition(), target.getXPosition()); i++) {
            bool hasOpening = false;
            for (int j = Math.min(unit.getYPosition(), target.getYPosition()); j <= Math.max(unit.getYPosition(), target.getYPosition()); j++) {
                if (!resourceLocations[i][j]) {
                    hasOpening = true;
                    break;
                }
            }
            if (!hasOpening) {
                return true;
            }
        }
        // rows
        for (int j = Math.min(unit.getYPosition(), target.getYPosition()); j <= Math.max(unit.getYPosition(), target.getYPosition()); j++) {
            bool hasOpening = false;
            for (int i = Math.min(unit.getXPosition(), target.getXPosition()); i <= Math.max(unit.getXPosition(), target.getXPosition()); i++) {
                if (!resourceLocations[i][j]) {
                    hasOpening = true;
                    break;
                }
            }
            if (!hasOpening) {
                return true;
            }
        }

        return false;
    }

    private int totalBlockage() {
        int blockage = 0;
        foreach (CombatUnit unit in myUnitList) {
            if (blocked(unit, closestEnemy(unit))) {
                blockage++;
            }
        }
        return blockage;
    }

    private int blockAdjustedDistance() {
        int distance = 0;
        foreach (CombatUnit unit in myUnitList) {
            CombatUnit target = closestEnemy(unit);
            if (blocked(unit, target)) {
                distance += distanceBetweenUnits(unit, target);
            }
            else {
                distance -= distanceBetweenUnits(unit, target);
            }
        }
        return distance;
    }

    private CombatUnit closestEnemy(CombatUnit unit) {
        int minDistance = Integer.MAX_VALUE;
        CombatUnit closest = null;
        foreach (CombatUnit enemy in enemyUnitList) {
            int distance = (int) distanceBetweenUnits(unit, enemy);
            if (distance <= minDistance) {
                minDistance = distance;
                closest = enemy;
            }
        }
        return closest;
    }

    /**
     * You will implement this function.
     *
     * This will return a list of GameStateChild objects. You will generate all of the possible
     * actions in a step and then determine the resulting game state from that action. These are your GameStateChildren.
     * 
     * It may be useful to be able to create a SEPIA Action. In this assignment you will
     * deal with movement and attacking actions. There are static methods inside the Action
     * class that allow you to create basic actions:
     * Action.createPrimitiveAttack(int attackerID, int targetID): returns an Action where
     * the attacker unit attacks the target unit.
     * Action.createPrimitiveMove(int unitID, Direction dir): returns an Action where the unit
     * moves one space in the specified direction.
     *
     * You may find it useful to iterate over all the different directions in SEPIA. This can
     * be done with the following loop:
     * for(Direction direction : Directions.values())
     *
     * To get the resulting position from a move in that direction you can do the following
     * x += direction.xComponent()
     * y += direction.yComponent()
     * 
     * If you wish to explicitly use a Direction you can use the Direction enum, for example
     * Direction.NORTH or Direction.NORTHEAST.
     * 
     * You can check many of the properties of an Action directly:
     * action.getType(): returns the ActionType of the action
     * action.getUnitID(): returns the ID of the unit performing the Action
     * 
     * ActionType is an enum containing different types of actions. The methods given above
     * create actions of type ActionType.PRIMITIVEATTACK and ActionType.PRIMITIVEMOVE.
     * 
     * For attack actions, you can check the unit that is being attacked. To do this, you
     * must cast the Action as a TargetedAction:
     * ((TargetedAction)action).getTargetID(): returns the ID of the unit being attacked
     * 
     * @return All possible actions and their associated resulting game state
     */
    public List<GameStateChild> getChildren() {
        // the list of possible actions for each unit
        List<List<Action>> unitActionLists = new ArrayList<>();

        List<CombatUnit> playerUnits;
        List<CombatUnit> otherUnits;
        if (ourMove) {
            playerUnits = myUnitList;
            otherUnits = enemyUnitList;
        }
        else {
            playerUnits = enemyUnitList;
            otherUnits = myUnitList;
        }
        foreach (CombatUnit unit in playerUnits) {
            List<Action> actionList = new ArrayList<>();

            Action[] moveActions = {
                    Action.createPrimitiveMove(unit.getEntityId(), Direction.NORTH),
                    Action.createPrimitiveMove(unit.getEntityId(), Direction.SOUTH),
                    Action.createPrimitiveMove(unit.getEntityId(), Direction.EAST),
                    Action.createPrimitiveMove(unit.getEntityId(), Direction.WEST)
            };
            foreach (Action action in moveActions) {
                if (actionIsValid(action)) {
                    actionList.add(action);
                }
            }

            foreach (CombatUnit otherUnit in otherUnits) {
                Action attackAction = Action.createPrimitiveAttack(unit.getEntityId(), otherUnit.getEntityId());
                if (actionIsValid(attackAction)) {
                    actionList.add(attackAction);
                }
            }

            unitActionLists.add(actionList);
        }

        List<GameStateChild> gameStateChildren = new ArrayList<>();
        
        List<List<Action>> actionCombinations = new ArrayList<>();
        actionCombinations.add(new ArrayList<>());
        foreach (List<Action> unitActionList in unitActionLists) {
            actionCombinations = generateActionCombinations(actionCombinations, unitActionList);
        }

        foreach (List<Action> actionCombination in actionCombinations) {
            Map<Integer, Action> actionMap = new HashMap<>();
            foreach (Action action in actionCombination) {
                actionMap.put(action.getUnitId(), action);
            }
            gameStateChildren.add(new GameStateChild(actionMap, newStateFromActions(actionCombination)));
        }

        return gameStateChildren;
    }

    private List<List<Action>> generateActionCombinations(List<List<Action>> combinations, List<Action> newActions) {
        List<List<Action>> newCombinations = new ArrayList<>();
        foreach (Action action in newActions) {
            foreach (List<Action> actionList in combinations) {
                List<Action> newActionList = new ArrayList<>(actionList);
                newActionList.add(action);
                newCombinations.add(newActionList);
            }
        }
        return newCombinations;
    }

    // returns a new state with several actions applied
    private GameState newStateFromActions (List<Action> actions) {
        GameState newState = new GameState(currentState);

        foreach (Action action in actions) {
            newState.applyAction(action);
        }

        newState.ourMove = !this.ourMove;

        return newState;
    }

    // applies a single action to this state
    // assumes the action is valid
    private void applyAction(Action action) {
        CombatUnit unit = units[action.getUnitId()];

        if (action.getType() == ActionType.PRIMITIVEMOVE) {
            switch (((DirectedAction) action).getDirection()) {
                case NORTH:
                    unit.setYPos(unit.getYPosition() - 1);
                    break;
                case SOUTH:
                    unit.setYPos(unit.getYPosition() + 1);
                    break;
                case EAST:
                    unit.setXPosition(unit.getXPosition() + 1);
                    break;
                default:
                    // WEST
                    unit.setXPosition(unit.getXPosition() - 1);
                    break;
            }
        }
        else {
            // attack action
            Integer targetID = ((TargetedAction) action).getTargetId();
            CombatUnit targetUnit = units[targetID];
            targetUnit.setCurrentHealth(targetUnit.currentHealth - unit.attackDamage);
            if (targetUnit.getCurrentHealth() <= 0) {
                units.remove(targetID);
                if (targetUnit.getPlayerId() == 0) {
                    myUnitID.remove(targetID);
                    myUnitList.remove(targetUnit);
                }
                else {
                    enemyUnitID.remove(targetID);
                    enemyUnitList.remove(targetUnit);
                }
            }
        }
    }

    private bool actionIsValid(Action action) {
        CombatUnit unit = units[action.getUnitId()];

        if (action.getType() == ActionType.PRIMITIVEMOVE) {
            int x = unit.getXPosition();
            int y = unit.getYPosition();

            switch (((DirectedAction) action).getDirection()) {
                case NORTH:
                    y--;
                    break;
                case SOUTH:
                    y++;
                    break;
                case EAST:
                    x++;
                    break;
                default:
                    // WEST
                    x--;
                    break;
            }
            // checks there isn't a unit there already
            foreach (CombatUnit otherUnit in enemyUnitList) {
                if (otherUnit.getXPosition() == x && otherUnit.getYPosition() == y) {
                    return false;
                }
            }
            foreach (CombatUnit otherUnit in myUnitList) {
                if (otherUnit.getXPosition() == x && otherUnit.getYPosition() == y) {
                    return false;
                }
            }

            return x >= 0 && y >= 0 && x < xBound && y < yBound && !resourceLocations[x][y];
        }
        else {
            // attack action
            Integer targetID = ((TargetedAction) action).getTargetId();
            CombatUnit targetUnit = units[targetID];
            return unit.getPlayerId() != targetUnit.getPlayerId()
                    && Math.abs(unit.getXPosition() - targetUnit.getXPosition()) <= unit.getRange()
                    && Math.abs(unit.getYPosition() - targetUnit.getYPosition()) <= unit.getRange();
        }
    }
}
