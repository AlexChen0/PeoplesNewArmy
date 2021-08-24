using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimaxAlphaBeta : MonoBehaviour
{
    /*
    //state is the current state of the board
    //dunno how we'll implement the state stuff yet
    public Map<Integer, Action> getBestAction(State.StateView newstate, History.HistoryView statehistory) {
        GameStateChild bestChild = alphaBetaSearch(new GameStateChild(newstate), numPlys, Double.NEGATIVE_INFINITY, Double.POSITIVE_INFINITY);
        return bestChild.action;
    }

    public GameStateChild alphaBetaSearch(GameStateChild node, int depth, double alpha, double beta)
    {
        if(depth==0)
            return node;
        // maximizing
        if (node.state.ourMove) {
            double value=Double.NEGATIVE_INFINITY;
            GameStateChild maxChild = null;
            List<GameStateChild> orderedChildren = orderChildrenWithHeuristics(findChildren(node));
            for(int i = 0; i < orderedChildren.length; i++){
                GameStateChild child = orderedChildre[i];
                if (maxChild == null) {
                    maxChild = child;
                }
                double utility = alphaBetaSearch(child, depth-1, alpha, beta).state.getUtility();
                if (utility > value) {
                    value = utility;
                    maxChild = child;
                }
                if (value >= beta) {
                    return child;
                }
                alpha=Math.max(alpha,value);
            }
            return maxChild;
        }
        // minimizing
        else{
            double value=Double.POSITIVE_INFINITY;
            GameStateChild minChild = null;
            List<GameStateChild> orderedChildren = orderChildrenWithHeuristics(findChildren(node));
            for(int i = 0; i < orderedChildren.length; i++){
                GameStateChild child = orderedChildre[i];
                if (minChild == null) {
                    minChild = child;
                }
                double utility = alphaBetaSearch(child, depth-1, alpha, beta).state.getUtility();
                if (utility < value) {
                    value = utility;
                    minChild = child;
                }
                if (value <= alpha) {
                    return child;
                }
                beta = Math.min(beta, value);
            }
            return minChild;
        }
    }

    public List<GameStateChild> orderChildrenWithHeuristics(List<GameStateChild> children)
    {
        children.Sort(CompareUtilities);
        return children;
    }

    private int getAttacks(GameStateChild node){
        int attacks=0;
        foreach(Action action in node.action.values()){
            if(action!=null && action.getType().name().equals(GameState.ATTACK_NAME))
                attacks++;
        }
        return attacks;
    }
    */
}

public class Sorting
{
    /*
    private int CompareUtilities(GameStateChild o1, GameStateChild o2) {
        int diff = getAttacks(o2) - getAttacks(o1);
        if (diff == 0) {
            diff = (int) (o2.state.getUtility() - o1.state.getUtility());
        }
        return diff;
    }
    */
}