
package etu.polytech.ws.client.generated;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ArrayOfLgbStep complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfLgbStep"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="LgbStep" type="{http://schemas.datacontract.org/2004/07/routing_server.Helper.open_route_objects}LgbStep" maxOccurs="unbounded" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfLgbStep", propOrder = {
    "lgbStep"
})
public class ArrayOfLgbStep {

    @XmlElement(name = "LgbStep", nillable = true)
    protected List<LgbStep> lgbStep;

    /**
     * Gets the value of the lgbStep property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the lgbStep property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getLgbStep().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link LgbStep }
     * 
     * 
     */
    public List<LgbStep> getLgbStep() {
        if (lgbStep == null) {
            lgbStep = new ArrayList<LgbStep>();
        }
        return this.lgbStep;
    }

}
